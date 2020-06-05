using System.Collections.Generic;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Application.Repositories
{
    public interface ISubscribedChatRepository
    {
        Task<SubscribedChat> GetById(long chatId);
        Task<IEnumerable<SubscribedChat>> GetAll();
        Task Insert(SubscribedChat subscribedChat);
        Task Delete(SubscribedChat subscribedChat);
        Task<SubscribedChat> OpenSubscribedChat();

    }
}
