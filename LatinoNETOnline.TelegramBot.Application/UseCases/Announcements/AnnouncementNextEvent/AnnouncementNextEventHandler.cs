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
        private readonly ISubscribedChatRepository _subscribedUsersRepository;
        private readonly IEventService _eventService;

        public AnnouncementNextEventHandler(IMediator mediator, ISubscribedChatRepository subscribedUsersRepository, IEventService eventService)
        {
            _mediator = mediator;
            _subscribedUsersRepository = subscribedUsersRepository;
            _eventService = eventService;
        }

        protected override async Task Handle(AnnouncementNextEventRequest request, CancellationToken cancellationToken)
        {
            var @event = await _eventService.GetNextEventAsync();

            if (@event != null && @event.Date > DateTime.Now.ToUniversalTime())
            {
                var users = await _subscribedUsersRepository.GetAll();

                foreach (var user in users)
                {
                    var nextEventImageRequest = new SendNextEventImageRequest(user.ChatId, new Uri(@event.ImageUrl), null);

                    var nextEventImageResponse = await _mediator.Send(nextEventImageRequest);

                    var nextEventTextRequest = new SendNextEventTextRequest(user.ChatId, nextEventImageResponse.MessageId, @event);

                    await _mediator.Send(nextEventTextRequest);
                }
            }  
        }
    }
}
