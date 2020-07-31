using System.Threading;
using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.SendMessage
{
    public class SendMessageHandler : AsyncRequestHandler<SendMessageRequest>
    {
        private readonly IBotMessageService _botMessageService;
        private readonly ISubscribedChatRepository _subscribedChatRepository;

        public SendMessageHandler(IBotMessageService botMessageService, ISubscribedChatRepository subscribedChatRepository)
        {
            _botMessageService = botMessageService;
            _subscribedChatRepository = subscribedChatRepository;
        }

        protected override async Task Handle(SendMessageRequest request, CancellationToken cancellationToken)
        {
            var chats = await _subscribedChatRepository.GetAll();

            foreach (var chat in chats)
            {
                int? messageId = null;

                if (request.ImageLink != null)
                {
                    messageId = await _botMessageService.SendImage(request.ImageLink, chat.ChatId, null);
                }

                if (!string.IsNullOrWhiteSpace(request.Message))
                {
                    await _botMessageService.SendText(request.Message, chat.ChatId, messageId);
                }
            }
        }
    }
}
