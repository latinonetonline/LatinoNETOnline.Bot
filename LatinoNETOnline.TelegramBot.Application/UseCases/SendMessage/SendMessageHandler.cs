using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if (request.Chats.Any())
            {
                foreach (var chatId in request.Chats)
                {
                    await SendMessageToChat(chatId);
                }
            }
            else
            {
                var chats = await _subscribedChatRepository.GetAll();

                foreach (var chat in chats)
                {
                    await SendMessageToChat(chat.ChatId);
                }
            }


            async Task SendMessageToChat(long chatId)
            {
                int? messageId = null;

                if (request.ImageLink != null)
                {
                    messageId = await _botMessageService.SendImage(request.ImageLink, chatId, null);
                }

                if (!string.IsNullOrWhiteSpace(request.Message))
                {
                    await _botMessageService.SendText(request.Message, chatId, messageId);
                }
            }
        }
    }
}
