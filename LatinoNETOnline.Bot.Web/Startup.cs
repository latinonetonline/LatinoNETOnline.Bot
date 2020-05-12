using System;
using System.Collections.Generic;
using RecurrentTasks;
using System.Threading.Tasks;

using LatinoNETOnline.Bot.Web.Bots;
using LatinoNETOnline.Bot.Web.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Telegram.Bot.Framework;
using Microsoft.Extensions.Configuration;
using LatinoNETOnline.Bot.Web.Commands;
using Microsoft.Extensions.Logging;

namespace LatinoNETOnline.Bot.Web
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
            #region Echoer Bot

            var echoBotOptions = new BotOptions<LatinoNETOnlineTelegramBot>();
            Configuration.GetSection(nameof(LatinoNETOnlineTelegramBot)).Bind(echoBotOptions);

            services.AddTelegramBot<LatinoNETOnlineTelegramBot>(echoBotOptions)
                .AddUpdateHandler<NextEventCommand>()
                .Configure();

            services.AddTask<BotUpdateGetterTask<LatinoNETOnlineTelegramBot>>();

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
                app.UseTelegramBotLongPolling<LatinoNETOnlineTelegramBot>();

                logger.LogInformation("Update getting task is scheduled for bot " + nameof(LatinoNETOnlineTelegramBot));
            }
            else
            {
                app.UseTelegramBotWebhook<LatinoNETOnlineTelegramBot>();

                logger.LogInformation("Webhook is set for bot " + nameof(LatinoNETOnlineTelegramBot));
            }

            #endregion


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
