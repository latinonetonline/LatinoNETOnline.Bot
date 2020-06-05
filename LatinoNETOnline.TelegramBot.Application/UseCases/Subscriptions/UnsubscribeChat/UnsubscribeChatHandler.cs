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
        private readonly ISubscribedUsersRepository _subscribedUsersRepository;

        public UnsubscribeChatHandler(ISubscribedUsersRepository subscribedUsersRepository)
        {
            _subscribedUsersRepository = subscribedUsersRepository;
        }

        protected override async Task Handle(UnsubscribeChatRequest request, CancellationToken cancellationToken)
        {
            var user = await _subscribedUsersRepository.GetById(request.ChatId);

            if (user != null)
            {
                SubscribedUser subscribedUser = await _subscribedUsersRepository.OpenSubscribedUser();
                subscribedUser.UserId = request.ChatId;

                await _subscribedUsersRepository.Delete(subscribedUser);
            }
        }
    }
}
