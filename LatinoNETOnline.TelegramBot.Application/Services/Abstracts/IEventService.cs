using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Application.Services.Abstracts
{
    public interface IEventService
    {
        Task<Event> GetNextEventAsync();
    }
}
