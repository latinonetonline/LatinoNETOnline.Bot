using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEvent;
using LatinoNETOnline.TelegramBot.Infrastructure.Providers;
using LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddOptions();

            services.AddHttpClient();

            services.AddAuthorization();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["IdentityServer:Host"];
                    options.ApiName = Configuration["IdentityServer:ApiResource"];
                    options.RequireHttpsMetadata = false;
                });

            services.AddGitHubClient(Configuration);

            services.AddTelegramBot(Configuration);

            services.AddServices();

            services.AddMediatR(typeof(SendNextEventRequest));

            services.AddFluentMigrator(Configuration);

            services.AddApiVersioning(Configuration);

            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseSwagger(provider);
        }
    }
}
