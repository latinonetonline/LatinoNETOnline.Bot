using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Application.UseCases.Messages.SendNextEventImage;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Announcements.AnnouncementHourLeft
{
    public class AnnouncementHourLeftHandler : AsyncRequestHandler<AnnouncementHourLeftRequest>
    {
        private readonly IMediator _mediator;
        private readonly ISubscribedChatRepository _subscribedUsersRepository;
        private readonly IEventService _eventService;
        private readonly IBotMessageService _botMessageService;

        public AnnouncementHourLeftHandler(IMediator mediator, ISubscribedChatRepository subscribedUsersRepository, IEventService eventService, IBotMessageService botMessageService)
        {
            _mediator = mediator;
            _subscribedUsersRepository = subscribedUsersRepository;
            _eventService = eventService;
            _botMessageService = botMessageService;
        }

        protected override async Task Handle(AnnouncementHourLeftRequest request, CancellationToken cancellationToken)
        {
            var @event = await _eventService.GetNextEventAsync();

            if (@event != null && @event.Date > DateTime.Now.ToUniversalTime())
            {
                var users = await _subscribedUsersRepository.GetAll();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("💥En 1 Hora Webinar💥");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("No olvides registrarte!!");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("https://latinonet.online/links#registro");

                foreach (var user in users)
                {
                    SendNextEventImageRequest sendEventImageRequest = new SendNextEventImageRequest(user.ChatId, new Uri(@event.ImageUrl), null);
                    var sendEventImageResponse = await _mediator.Send(sendEventImageRequest);

                    await _botMessageService.SendText(stringBuilder.ToString(), user.ChatId, sendEventImageResponse.MessageId);
                }
            }
        }
    }
}
