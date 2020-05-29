using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEvent;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Announcements.AnnouncementNextEvent
{
    public class AnnouncementNextEventHandler : AsyncRequestHandler<AnnouncementNextEventRequest>
    {
        private readonly IMediator _mediator;
        private readonly ISubscribedUsersRepository _subscribedUsersRepository;

        public AnnouncementNextEventHandler(IMediator mediator, ISubscribedUsersRepository subscribedUsersRepository)
        {
            _mediator = mediator;
            _subscribedUsersRepository = subscribedUsersRepository;
        }

        protected override async Task Handle(AnnouncementNextEventRequest request, CancellationToken cancellationToken)
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
