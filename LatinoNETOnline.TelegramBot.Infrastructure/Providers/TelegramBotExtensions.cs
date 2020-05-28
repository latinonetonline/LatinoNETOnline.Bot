
using LatinoNETOnline.TelegramBot.Application.Bots;
using LatinoNETOnline.TelegramBot.Application.Bots.Commands;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Telegram.Bot.Framework;

namespace LatinoNETOnline.TelegramBot.Infrastructure.Providers
{
    public static class TelegramBotExtensions
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration configuration)
        {
            var echoBotOptions = new BotOptions<LatinoNetOnlineTelegramBot>();
            configuration.GetSection(nameof(LatinoNetOnlineTelegramBot)).Bind(echoBotOptions);

            services.AddTelegramBot(echoBotOptions)
                .AddUpdateHandler<NextEventCommand>()
                .AddUpdateHandler<SubscribeCommand>()
                .AddUpdateHandler<UnsubscribeCommand>()
                .AddUpdateHandler<InfoCommand>()
                .Configure();

            return services;
        }
    }
}
