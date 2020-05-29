
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;

namespace LatinoNETOnline.TelegramBot.Infrastructure.Providers
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IGitHubService, GitHubService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IBotMessageService, BotMessageService>();

            return services;
        }
    }
}
