using System.Linq;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Infrastructure.DataAccess.Entities;

using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.UpdateHandlers
{
    public class AddedMeToGroupHandler : IUpdateHandler
    {
        private readonly ISubscribedUsersRepository _subscribedUsersRepository;

        public AddedMeToGroupHandler(ISubscribedUsersRepository subscribedUsersRepository)
        {
            _subscribedUsersRepository = subscribedUsersRepository;
        }

        public bool CanHandleUpdate(IBot bot, Update update)
        {
            return update.Message.NewChatMembers?.Any(x => x.Username == bot.UserName) ?? false;
        }

        public async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            SubscribedUser subscribedUser = new SubscribedUser
            {
                UserId = update.Message.Chat.Id
            };


            await _subscribedUsersRepository.Insert(subscribedUser);
            return UpdateHandlingResult.Continue;
        }
    }
}
