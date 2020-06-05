using System.Linq;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.SubscribeChat;
using LatinoNETOnline.TelegramBot.Infrastructure.DataAccess.Entities;
using MediatR;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.GroupUpdateHandlers
{
    public class AddedMeToGroupHandler : IUpdateHandler
    {
        private readonly IMediator _mediator;

        public AddedMeToGroupHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool CanHandleUpdate(IBot bot, Update update)
        {
            return update.Message.NewChatMembers?.Any(x => x.Username == bot.UserName) ?? false;
        }

        public async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            SubscribeChatRequest subscribeChatRequest = new SubscribeChatRequest(update.Message.Chat.Id);
            await _mediator.Send(subscribeChatRequest);

            return UpdateHandlingResult.Continue;
        }
    }
}
