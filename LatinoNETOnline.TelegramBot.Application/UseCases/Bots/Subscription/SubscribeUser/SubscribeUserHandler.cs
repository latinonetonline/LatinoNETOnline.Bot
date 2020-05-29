using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Domain;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Subscription.SubscribeUser
{
    public class SubscribeUserHandler : AsyncRequestHandler<SubscribeUserRequest>
    {
        private readonly IBotMessageService _botMessageService;
        private readonly ISubscribedUsersRepository _subscribedUsersRepository;

        public SubscribeUserHandler(IBotMessageService botMessageService, ISubscribedUsersRepository subscribedUsersRepository)
        {
            _botMessageService = botMessageService;
            _subscribedUsersRepository = subscribedUsersRepository;
        }

        protected override async Task Handle(SubscribeUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _subscribedUsersRepository.GetById(request.UserId);

            if (user is null)
            {
                SubscribedUser subscribedUser = await _subscribedUsersRepository.OpenSubscribedUser();
                subscribedUser.UserId = request.UserId;


                await _subscribedUsersRepository.Insert(subscribedUser);

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"🎉 *Bienvenido/a* {request.UserFirstName} 🎉");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Nos alegra que te hayas suscrito al bot de Latino .NET Online 🤖");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("A partir de ahora recibirás todas las noticias de la comunidad.");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Estarás al tanto de los anuncios y recordatorios de nuestros próximos webinars📲, te  avisaremos cuando haya un nuevo artículo en nuestro blog, estarás al tanto de eventos de otras comunidades🤝🏻, y más! Todo en este mismo chat.");

                await _botMessageService.SendText(stringBuilder.ToString(),
                    request.UserId,
                    request.ReplyToMessageId);
            }
            else
            {
                await _botMessageService.SendText("Actualmente ya te encuentras subscripto. Que Bueno!",
                    request.UserId,
                    request.ReplyToMessageId);
            }
        }
    }
}
