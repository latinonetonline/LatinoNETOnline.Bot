using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Subscription.UnsubscribeUser;

using MediatR;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.Commands
{
    public class UnsubscribeCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class UnsubscribeCommand : CommandBase<UnsubscribeCommandArgs>
    {
        private readonly IMediator _mediator;
        public UnsubscribeCommand(IMediator mediator) : base(CommandConsts.UNSUBSCRIBE)
        {
            _mediator = mediator;
        }

        public override async Task<UpdateHandlingResult> HandleCommand(Update update, UnsubscribeCommandArgs args)
        {
            var userIdToUnsubscribe = update.Message.From.Id;
            var replyToMessageId = update.Message.From.Id == update.Message.Chat.Id ? update.Message.MessageId : default;

            UnsubscribeUserRequest unsubscribeUserRequest = new UnsubscribeUserRequest(userIdToUnsubscribe, replyToMessageId);

            await _mediator.Send(unsubscribeUserRequest);

            return UpdateHandlingResult.Continue;
        }
    }
}
