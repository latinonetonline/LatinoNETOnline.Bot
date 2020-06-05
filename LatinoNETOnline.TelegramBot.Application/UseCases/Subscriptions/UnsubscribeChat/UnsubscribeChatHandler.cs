using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Domain;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.UnsubscribeChat
{
    public class UnsubscribeChatHandler : AsyncRequestHandler<UnsubscribeChatRequest>
    {
        private readonly ISubscribedChatRepository _subscribedChatRepository;

        public UnsubscribeChatHandler(ISubscribedChatRepository subscribedChatRepository)
        {
            _subscribedChatRepository = subscribedChatRepository;
        }

        protected override async Task Handle(UnsubscribeChatRequest request, CancellationToken cancellationToken)
        {
            var chat = await _subscribedChatRepository.GetById(request.ChatId);

            if (chat != null)
            {
                SubscribedChat subscribedChat = await _subscribedChatRepository.OpenSubscribedChat();
                subscribedChat.ChatId = request.ChatId;

                await _subscribedChatRepository.Delete(subscribedChat);
            }
        }
    }
}
