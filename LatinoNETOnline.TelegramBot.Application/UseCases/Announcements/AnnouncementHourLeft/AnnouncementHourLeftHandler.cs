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
        private readonly ISubscribedChatRepository _subscribedChatRepository;
        private readonly IEventService _eventService;
        private readonly IBotMessageService _botMessageService;

        public AnnouncementHourLeftHandler(IMediator mediator, ISubscribedChatRepository subscribedChatRepository, IEventService eventService, IBotMessageService botMessageService)
        {
            _mediator = mediator;
            _subscribedChatRepository = subscribedChatRepository;
            _eventService = eventService;
            _botMessageService = botMessageService;
        }

        protected override async Task Handle(AnnouncementHourLeftRequest request, CancellationToken cancellationToken)
        {
            var @event = await _eventService.GetNextEventAsync();

            if (@event != null && @event.Date > DateTime.Now.ToUniversalTime())
            {
                var chats = await _subscribedChatRepository.GetAll();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("💥En 1 Hora Webinar💥");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("No olvides registrarte!!");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("https://latinonet.online/links#registro");

                foreach (var chat in chats)
                {
                    SendNextEventImageRequest sendEventImageRequest = new SendNextEventImageRequest(chat.ChatId, new Uri(@event.ImageUrl), null);
                    var sendEventImageResponse = await _mediator.Send(sendEventImageRequest);

                    await _botMessageService.SendText(stringBuilder.ToString(), chat.ChatId, sendEventImageResponse.MessageId);
                }
            }
        }
    }
}
