using System;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Application.UseCases.Messages.SendNextEvent;
using LatinoNETOnline.TelegramBot.Application.UseCases.Messages.SendNextEventImage;
using LatinoNETOnline.TelegramBot.Application.UseCases.Messages.SendNextEventText;
using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Announcements.AnnouncementNextEvent
{
    public class AnnouncementNextEventHandler : AsyncRequestHandler<AnnouncementNextEventRequest>
    {
        private readonly IMediator _mediator;
        private readonly ISubscribedChatRepository _subscribedChatRepository;
        private readonly IEventService _eventService;

        public AnnouncementNextEventHandler(IMediator mediator, ISubscribedChatRepository subscribedChatRepository, IEventService eventService)
        {
            _mediator = mediator;
            _subscribedChatRepository = subscribedChatRepository;
            _eventService = eventService;
        }

        protected override async Task Handle(AnnouncementNextEventRequest request, CancellationToken cancellationToken)
        {
            var @event = await _eventService.GetNextEventAsync();

            if (@event != null && @event.Date > DateTime.Now.ToUniversalTime())
            {
                var chats = await _subscribedChatRepository.GetAll();

                foreach (var chat in chats)
                {
                    var nextEventImageRequest = new SendNextEventImageRequest(chat.ChatId, new Uri(@event.ImageUrl), null);

                    var nextEventImageResponse = await _mediator.Send(nextEventImageRequest);

                    var nextEventTextRequest = new SendNextEventTextRequest(chat.ChatId, nextEventImageResponse.MessageId, @event);

                    await _mediator.Send(nextEventTextRequest);
                }
            }  
        }
    }
}
