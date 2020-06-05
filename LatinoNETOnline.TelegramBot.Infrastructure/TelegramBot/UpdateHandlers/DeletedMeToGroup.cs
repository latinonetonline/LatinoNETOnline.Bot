using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Domain;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.UpdateHandlers
{
    public class DeletedMeToGroup : IUpdateHandler
    {
        private readonly ISubscribedUsersRepository _subscribedUsersRepository;

        public DeletedMeToGroup(ISubscribedUsersRepository subscribedUsersRepository)
        {
            _subscribedUsersRepository = subscribedUsersRepository;
        }

        public bool CanHandleUpdate(IBot bot, Update update)
        {
            return update.Message.LeftChatMember?.Username == bot.UserName;
        }

        public async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            SubscribedUser subscribedUser = await _subscribedUsersRepository.GetById(update.Message.Chat.Id);
            if (subscribedUser != null)
            {
                await _subscribedUsersRepository.Delete(subscribedUser);
            }

            return UpdateHandlingResult.Continue;
        }
    }
}
