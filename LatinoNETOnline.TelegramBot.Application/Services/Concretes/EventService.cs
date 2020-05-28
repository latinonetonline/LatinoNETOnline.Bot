using System.Text.Json;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Options;
using LatinoNETOnline.TelegramBot.Application.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Domain;

using Microsoft.Extensions.Options;

namespace LatinoNETOnline.TelegramBot.Application.Services.Concretes
{
    public class EventService : IEventService
    {
        private readonly IGitHubService _githubService;

        public EventService(IGitHubService githubService)
        {
            _githubService = githubService;
        }

        public async Task<Event> GetNextEventAsync()
        {
            FileContent file = await _githubService.GetFileContentAsync(251758832, "events", "NextEvent");
            return JsonSerializer.Deserialize<Event>(file.Content);
        }
    }
}
