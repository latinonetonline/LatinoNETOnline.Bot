using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.GetSubscribedUsers
{
    public class GetSubscribedUsersHandler : IRequestHandler<GetSubscribedUsersRequest, GetSubscribedUsersResponse>
    {
        private readonly ISubscribedUsersRepository _subscribedUsersRepository;

        public GetSubscribedUsersHandler(ISubscribedUsersRepository subscribedUsersRepository)
        {
            _subscribedUsersRepository = subscribedUsersRepository;
        }

        public async Task<GetSubscribedUsersResponse> Handle(GetSubscribedUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _subscribedUsersRepository.GetAll();

            return new GetSubscribedUsersResponse
            {
                SubscribedUsers = users
            };
        }
    }
}
