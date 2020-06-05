using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Domain;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.SubscribeChat
{
    public class SubscribeChatHandler : AsyncRequestHandler<SubscribeChatRequest>
    {
        private readonly ISubscribedChatRepository _subscribedChatRepository;

        public SubscribeChatHandler(ISubscribedChatRepository subscribedChatRepository)
        {
            _subscribedChatRepository = subscribedChatRepository;
        }

        protected override async Task Handle(SubscribeChatRequest request, CancellationToken cancellationToken)
        {
            var chat = await _subscribedChatRepository.GetById(request.ChatId);

            if (chat is null)
            {
                SubscribedChat subscribedChat = await _subscribedChatRepository.OpenSubscribedChat();
                subscribedChat.ChatId = request.ChatId;

                await _subscribedChatRepository.Insert(subscribedChat);
            }
        }
    }
}
