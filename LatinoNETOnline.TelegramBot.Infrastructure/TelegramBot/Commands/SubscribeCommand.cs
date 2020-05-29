using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Subscription.SubscribeUser;

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
            var replyToMessageId = update.Message.MessageId;

            SubscribeUserRequest subscribeUserRequest = new SubscribeUserRequest(userIdToSubscribe, replyToMessageId);

            await _mediator.Send(subscribeUserRequest);

            return UpdateHandlingResult.Continue;
        }
    }
}
