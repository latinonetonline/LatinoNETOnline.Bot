using System;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEvent;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Announcements.AnnouncementNextEvent
{
    public class AnnouncementNextEventHandler : AsyncRequestHandler<AnnouncementNextEventRequest>
    {
        private readonly IMediator _mediator;
        private readonly ISubscribedUsersRepository _subscribedUsersRepository;
        private readonly IEventService _eventService;

        public AnnouncementNextEventHandler(IMediator mediator, ISubscribedUsersRepository subscribedUsersRepository, IEventService eventService)
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
                    SendNextEventRequest sendNextEventRequest = new SendNextEventRequest(user.UserId, null);
                    await _mediator.Send(sendNextEventRequest);
                }
            }  
        }
    }
}
