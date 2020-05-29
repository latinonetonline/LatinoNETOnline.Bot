
using LatinoNETOnline.TelegramBot.Infrastructure.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Octokit;

namespace LatinoNETOnline.TelegramBot.Infrastructure.Providers
{
    public static class GitHubClientExtensions
    {
        public static IServiceCollection AddGitHubClient(this IServiceCollection services, IConfiguration configuration)
        {

            var githubOptions = new GitHubOptions();

            configuration.GetSection(nameof(GitHubOptions)).Bind(githubOptions);

            GitHubClient githubClient = new GitHubClient(new ProductHeaderValue(nameof(LatinoNETOnline)));
            Credentials basicAuth = new Credentials(githubOptions.Token);
            githubClient.Credentials = basicAuth;

            services.AddSingleton<IGitHubClient, GitHubClient>(service => githubClient);

            return services;
        }
    }
}
