
using FluentMigrator.Runner;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LatinoNETOnline.TelegramBot.Infrastructure.Providers
{
    public static class FluentMigrationExtensions
    {
        public static IServiceCollection AddFluentMigrator(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(configuration.GetConnectionString("Default"))
                    .ScanIn(typeof(FluentMigrationExtensions).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }
    }
}
