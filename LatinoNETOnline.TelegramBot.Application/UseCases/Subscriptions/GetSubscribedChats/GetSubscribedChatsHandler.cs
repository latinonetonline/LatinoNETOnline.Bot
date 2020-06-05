using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.GetSubscribedChats
{
    public class GetSubscribedChatsHandler : IRequestHandler<GetSubscribedChatsRequest, GetSubscribedChatsResponse>
    {
        private readonly ISubscribedChatRepository _subscribedUsersRepository;

        public GetSubscribedChatsHandler(ISubscribedChatRepository subscribedUsersRepository)
        {
            _subscribedUsersRepository = subscribedUsersRepository;
        }

        public async Task<GetSubscribedChatsResponse> Handle(GetSubscribedChatsRequest request, CancellationToken cancellationToken)
        {
            var users = await _subscribedUsersRepository.GetAll();

            return new GetSubscribedChatsResponse
            {
                SubscribedUsers = users
            };
        }
    }
}
