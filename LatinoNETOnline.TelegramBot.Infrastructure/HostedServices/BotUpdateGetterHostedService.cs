using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Framework.Abstractions;

namespace LatinoNETOnline.TelegramBot.Infrastructure.HostedServices
{
    public class BotUpdateGetterHostedService : BackgroundService
    {
        private readonly ILogger<BotUpdateGetterHostedService> _logger;
        private readonly IWebHostEnvironment _env;

        public BotUpdateGetterHostedService(ILogger<BotUpdateGetterHostedService> logger, IServiceProvider services, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            Services = services;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_env.IsDevelopment())
            {
                _logger.LogInformation("Consume Scoped Service Hosted Service running.");

                await DoWork(stoppingToken);
            }
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service is working.");

            using (var scope = Services.CreateScope())
            {
                var botManager = scope.ServiceProvider.GetRequiredService<IBotManager<LatinoNetOnlineTelegramBot>>();

                await botManager.SetWebhookStateAsync(false);

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogTrace($"{typeof(LatinoNetOnlineTelegramBot).Name}: Checking for updates...");

                    await botManager.GetAndHandleNewUpdatesAsync();

                    _logger.LogTrace($"{typeof(LatinoNetOnlineTelegramBot).Name}: Handling updates finished");

                    await Task.Delay(1000, stoppingToken);
                }
            }
        }


    }
}
