using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.GetSubscribedChats
{
    public class GetSubscribedChatsHandler : IRequestHandler<GetSubscribedChatsRequest, GetSubscribedChatsResponse>
    {
        private readonly ISubscribedChatRepository _subscribedChatRepository;

        public GetSubscribedChatsHandler(ISubscribedChatRepository subscribedChatRepository)
        {
            _subscribedChatRepository = subscribedChatRepository;
        }

        public async Task<GetSubscribedChatsResponse> Handle(GetSubscribedChatsRequest request, CancellationToken cancellationToken)
        {
            var chats = await _subscribedChatRepository.GetAll();

            return new GetSubscribedChatsResponse
            {
                SubscribedChats = chats
            };
        }
    }
}
