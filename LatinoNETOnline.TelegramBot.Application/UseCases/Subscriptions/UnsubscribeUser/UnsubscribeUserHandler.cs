using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Domain;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.UnsubscribeUser
{
    public class UnsubscribeUserHandler : AsyncRequestHandler<UnsubscribeUserRequest>
    {
        private readonly IBotMessageService _botMessageService;
        private readonly ISubscribedChatRepository _subscribedChatRepository;

        public UnsubscribeUserHandler(IBotMessageService botMessageService, ISubscribedChatRepository subscribedChatRepository)
        {
            _botMessageService = botMessageService;
            _subscribedChatRepository = subscribedChatRepository;
        }

        protected override async Task Handle(UnsubscribeUserRequest request, CancellationToken cancellationToken)
        {
            var chat = await _subscribedChatRepository.GetById(request.UserId);

            if (chat is null)
            {
                await _botMessageService.SendText("No te encuentras suscripto",
                    request.UserId,
                    request.ReplyToMessageId);
            }
            else
            {
                SubscribedChat subscribedChat = await _subscribedChatRepository.OpenSubscribedChat();
                subscribedChat.ChatId = request.UserId;

                await _subscribedChatRepository.Delete(subscribedChat);

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
