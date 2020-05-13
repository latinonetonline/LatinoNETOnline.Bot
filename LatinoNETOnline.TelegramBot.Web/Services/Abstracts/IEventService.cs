using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Services.Models;

namespace LatinoNETOnline.TelegramBot.Services.Abstracts
{
    public interface IEventService
    {
        Task<Event> GetNextEventAsync();
    }
}
