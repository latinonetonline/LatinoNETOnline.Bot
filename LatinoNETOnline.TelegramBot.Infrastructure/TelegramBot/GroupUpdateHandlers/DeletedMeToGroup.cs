using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.UnsubscribeChat;
using LatinoNETOnline.TelegramBot.Domain;
using MediatR;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.GroupUpdateHandlers
{
    public class DeletedMeToGroup : IUpdateHandler
    {
        private readonly IMediator _mediator;

        public DeletedMeToGroup(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool CanHandleUpdate(IBot bot, Update update)
        {
            return update.Message.LeftChatMember?.Username == bot.UserName;
        }

        public async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            UnsubscribeChatRequest unsubscribeChatRequest = new UnsubscribeChatRequest(update.Message.Chat.Id);
            await _mediator.Send(unsubscribeChatRequest);

            return UpdateHandlingResult.Continue;
        }
    }
}
