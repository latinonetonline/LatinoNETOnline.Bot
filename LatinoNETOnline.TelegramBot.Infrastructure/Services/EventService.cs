using System.Text.Json;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Infrastructure.Services
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
