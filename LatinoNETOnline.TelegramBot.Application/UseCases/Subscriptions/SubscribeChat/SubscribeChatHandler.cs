using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Domain;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.SubscribeChat
{
    public class SubscribeChatHandler : AsyncRequestHandler<SubscribeChatRequest>
    {
        private readonly ISubscribedChatRepository _subscribedUsersRepository;

        public SubscribeChatHandler(ISubscribedChatRepository subscribedUsersRepository)
        {
            _subscribedUsersRepository = subscribedUsersRepository;
        }

        protected override async Task Handle(SubscribeChatRequest request, CancellationToken cancellationToken)
        {
            var user = await _subscribedUsersRepository.GetById(request.ChatId);

            if (user is null)
            {
                SubscribedChat subscribedUser = await _subscribedUsersRepository.OpenSubscribedUser();
                subscribedUser.ChatId = request.ChatId;

                await _subscribedUsersRepository.Insert(subscribedUser);
            }
        }
    }
}
