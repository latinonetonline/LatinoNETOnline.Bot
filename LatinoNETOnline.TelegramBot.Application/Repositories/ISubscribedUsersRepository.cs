using System.Collections.Generic;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Application.Repositories
{
    public interface ISubscribedUsersRepository
    {
        Task<SubscribedUser> GetById(long userId);
        Task<IEnumerable<SubscribedUser>> GetAll();
        Task Insert(SubscribedUser subscribedUser);
        Task Delete(SubscribedUser subscribedUser);
        Task<SubscribedUser> OpenSubscribedUser();

    }
}
