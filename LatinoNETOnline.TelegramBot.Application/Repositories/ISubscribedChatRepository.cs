using System.Collections.Generic;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Application.Repositories
{
    public interface ISubscribedChatRepository
    {
        Task<SubscribedChat> GetById(long userId);
        Task<IEnumerable<SubscribedChat>> GetAll();
        Task Insert(SubscribedChat subscribedUser);
        Task Delete(SubscribedChat subscribedUser);
        Task<SubscribedChat> OpenSubscribedUser();

    }
}
