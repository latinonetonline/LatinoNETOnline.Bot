
using LatinoNETOnline.TelegramBot.Application.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Application.Services.Concretes;

using Microsoft.Extensions.DependencyInjection;

namespace LatinoNETOnline.TelegramBot.Infrastructure.Providers
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IGitHubService, GitHubService>();
            services.AddSingleton<IEventService, EventService>();

            return services;
        }
    }
}
