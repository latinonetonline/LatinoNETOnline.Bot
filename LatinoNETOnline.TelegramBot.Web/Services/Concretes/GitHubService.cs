using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Services.Models;
using LatinoNETOnline.TelegramBot.Services.Options;

using Microsoft.Extensions.Options;

using Octokit;

namespace LatinoNETOnline.TelegramBot.Services.Concretes
{
    public class GitHubService : IGitHubService
    {
        private readonly IGitHubClient _githubClient;
        private readonly GitHubOptions _githubOptions;
        private readonly HttpClient _httpClient;

        public GitHubService(IGitHubClient githubClient, IOptions<GitHubOptions> options, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _githubClient = githubClient;
            _githubOptions = options.Value;
        }

        public async Task<FileContent> GetFileContentAsync(long repositoryId, string path, string fileName)
        {
            try
            {
                IReadOnlyList<RepositoryContent> contents = await _githubClient.Repository.Content.GetAllContents(repositoryId, Path.Combine(path, fileName));
                RepositoryContent content = contents.First();
                return new FileContent()
                {
                    Name = content.Name,
                    Content = content.Content,
                    DownloadUrl = content.DownloadUrl
                };
            }
            catch (Octokit.NotFoundException)
            {
                return null;
            }
        }
    }
}
