using System;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Services.Concretes;
using LatinoNETOnline.TelegramBot.Services.Options;
using LatinoNETOnline.TelegramBot.Web.Bots;
using LatinoNETOnline.TelegramBot.Web.Bots.Commands;
using LatinoNETOnline.TelegramBot.Web.Services.Concretes;
using LatinoNETOnline.TelegramBot.Web.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Octokit;

using RecurrentTasks;

using Telegram.Bot.Framework;

namespace LatinoNETOnline.TelegramBot.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IGitHubService, GitHubService>();
            services.AddSingleton<IEventService, EventService>();
            services.AddHttpClient();

            #region GitHub

            var githubOptions = new GitHubOptions();
            Configuration.GetSection(nameof(GitHubOptions)).Bind(githubOptions);
            GitHubClient githubClient = new GitHubClient(new ProductHeaderValue(nameof(LatinoNETOnline)));
            Credentials basicAuth = new Credentials(githubOptions.Token);
            githubClient.Credentials = basicAuth;

            services.AddSingleton<IGitHubClient, GitHubClient>(service => githubClient);

            services.Configure<GitHubOptions>(Configuration.GetSection(nameof(GitHubOptions)));

            #endregion


            #region Echoer Bot

            var echoBotOptions = new BotOptions<LatinoNetOnlineTelegramBot>();
            Configuration.GetSection(nameof(LatinoNetOnlineTelegramBot)).Bind(echoBotOptions);

            services.AddTelegramBot(echoBotOptions)
                .AddUpdateHandler<NextEventCommand>()
                .Configure();

            services.AddTask<BotUpdateGetterTask<LatinoNetOnlineTelegramBot>>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            ILogger logger = loggerFactory.CreateLogger<Startup>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                    appBuilder.Run(context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        return Task.CompletedTask;
                    })
                );
            }

            #region Echoer Bot

            if (env.IsDevelopment())
            {
                app.UseTelegramBotLongPolling<LatinoNetOnlineTelegramBot>();
                app.StartTask<BotUpdateGetterTask<LatinoNetOnlineTelegramBot>>(TimeSpan.FromSeconds(8), TimeSpan.FromSeconds(3));
                logger.LogInformation("Update getting task is scheduled for bot " + nameof(LatinoNetOnlineTelegramBot));
            }
            else
            {
                app.UseTelegramBotWebhook<LatinoNetOnlineTelegramBot>();

                logger.LogInformation("Webhook is set for bot " + nameof(LatinoNetOnlineTelegramBot));
            }

            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
