using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEventImage;
using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEventText;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEvent
{
    public class SendNextEventHandler : AsyncRequestHandler<SendNextEventRequest>
    {
        private readonly IEventService _eventService;
        private readonly IMediator _mediator;
        private readonly IBotMessageService _botMessageService;

        public SendNextEventHandler(IEventService eventService, IMediator mediator, IBotMessageService botMessageService)
        {
            _eventService = eventService;
            _mediator = mediator;
            _botMessageService = botMessageService;
        }

        protected override async Task Handle(SendNextEventRequest request, CancellationToken cancellationToken)
        {
            var @event = await _eventService.GetNextEventAsync();

            if (@event is null || @event.Date < DateTime.Now.ToUniversalTime())
            {
                await _botMessageService.SendText(@"Por le momento no se ha cargado un nuevo evento.", request.ChatId, request.ReplyToMessageId);
            }
            else
            {
                var nextEventImageRequest = new SendNextEventImageRequest(request.ChatId, new Uri(@event.ImageUrl), null);

                var nextEventImageResponse = await _mediator.Send(nextEventImageRequest);

                var nextEventTextRequest = new SendNextEventTextRequest(request.ChatId, nextEventImageResponse.MessageId, @event);

                await _mediator.Send(nextEventTextRequest);
            }
        }
    }
}
