
using LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot;
using LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.Commands;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Telegram.Bot.Framework;

namespace LatinoNETOnline.TelegramBot.Infrastructure.Providers
{
    public static class TelegramBotExtensions
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration configuration)
        {
            var botOptions = new BotOptions<LatinoNetOnlineTelegramBot>();
            configuration.GetSection(nameof(LatinoNetOnlineTelegramBot)).Bind(botOptions);

            services.AddTelegramBot(botOptions)
                .AddUpdateHandler<NextEventCommand>()
                .AddUpdateHandler<SubscribeCommand>()
                .AddUpdateHandler<UnsubscribeCommand>()
                .AddUpdateHandler<InfoCommand>()
                .Configure();

            return services;
        }
    }
}
