using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.SubscribeUser;

using MediatR;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.Commands
{
    public class SubscribeCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class SubscribeCommand : CommandBase<SubscribeCommandArgs>
    {
        private readonly IMediator _mediator;
        public SubscribeCommand(IMediator mediator) : base(CommandConsts.SUBSCRIBE)
        {
            _mediator = mediator;
        }
        public override async Task<UpdateHandlingResult> HandleCommand(Update update, SubscribeCommandArgs args)
        {
            var userIdToSubscribe = update.Message.From.Id;
            var userFirstName = update.Message.From.FirstName;
            var replyToMessageId = update.Message.From.Id == update.Message.Chat.Id ? update.Message.MessageId : default;

            SubscribeUserRequest subscribeUserRequest = new SubscribeUserRequest(userIdToSubscribe, userFirstName, replyToMessageId);

            await _mediator.Send(subscribeUserRequest);

            return UpdateHandlingResult.Continue;
        }
    }
}
