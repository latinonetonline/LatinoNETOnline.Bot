using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Domain;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Subscription.UnsubscribeUser
{
    public class UnsubscribeUserHandler : AsyncRequestHandler<UnsubscribeUserRequest>
    {
        private readonly IBotMessageService _botMessageService;
        private readonly ISubscribedUsersRepository _subscribedUsersRepository;

        public UnsubscribeUserHandler(IBotMessageService botMessageService, ISubscribedUsersRepository subscribedUsersRepository)
        {
            _botMessageService = botMessageService;
            _subscribedUsersRepository = subscribedUsersRepository;
        }

        protected override async Task Handle(UnsubscribeUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _subscribedUsersRepository.GetById(request.UserId);

            if (user is null)
            {
                await _botMessageService.SendText("No te encuentras suscripto",
                    request.UserId,
                    request.ReplyToMessageId);
            }
            else
            {
                SubscribedUser subscribedUser = await _subscribedUsersRepository.OpenSubscribedUser();
                subscribedUser.UserId = request.UserId;

                await _subscribedUsersRepository.Delete(subscribedUser);

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Es una pena que te vayas 😭");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Pero recuerda que puedes volver a suscribirte cuando quieras para seguir recibiendo las últimas noticias de la comunidad. Hasta pronto!");

                await _botMessageService.SendText(stringBuilder.ToString(),
                    request.UserId,
                    request.ReplyToMessageId);
            }
        }
    }
}
