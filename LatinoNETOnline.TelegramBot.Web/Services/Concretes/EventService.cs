using System.Text.Json;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Services.Models;
using LatinoNETOnline.TelegramBot.Services.Options;

using Microsoft.Extensions.Options;

namespace LatinoNETOnline.TelegramBot.Web.Services.Concretes
{
    public class EventService : IEventService
    {
        private readonly IGitHubService _githubService;
        private readonly GitHubOptions _githubOptions;

        public EventService(IGitHubService githubService, IOptions<GitHubOptions> options)
        {
            _githubService = githubService;
            _githubOptions = options.Value;
        }

        public async Task<Event> GetNextEventAsync()
        {
            FileContent file = await _githubService.GetFileContentAsync(_githubOptions.EventRepositoryId, "events", "NextEvent");
            return JsonSerializer.Deserialize<Event>(file.Content);
        }
    }
}
