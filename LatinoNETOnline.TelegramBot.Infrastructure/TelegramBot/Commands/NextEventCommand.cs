using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEvent;

using MediatR;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.Commands
{

    public class NextEventCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class NextEventCommand : CommandBase<NextEventCommandArgs>
    {
        private readonly IMediator _mediator;

        public NextEventCommand(IMediator mediator) : base(CommandConsts.NEXT_EVENT)
        {
            _mediator = mediator;
        }

        public override async Task<UpdateHandlingResult> HandleCommand(Update update, NextEventCommandArgs args)
        {
            SendNextEventRequest request = new SendNextEventRequest(update.Message.Chat.Id, update.Message.MessageId);

            await _mediator.Send(request);

            return UpdateHandlingResult.Continue;
        }
    }
}
