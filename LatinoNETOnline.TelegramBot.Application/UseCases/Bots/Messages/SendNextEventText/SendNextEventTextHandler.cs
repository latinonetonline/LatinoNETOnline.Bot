using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Application.Enums;
using LatinoNETOnline.TelegramBot.Application.Services;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEventText
{
    public class SendNextEventTextHandler : AsyncRequestHandler<SendNextEventTextRequest>
    {
        private readonly IBotMessageService _botMessageService;
        public SendNextEventTextHandler(IBotMessageService botMessageService)
        {
            _botMessageService = botMessageService;
        }

        protected override Task Handle(SendNextEventTextRequest request, CancellationToken cancellationToken)
        {
            var @event = request.Event; 

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("🚨 *Proximo Evento* 🚨");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"🕔Cuando: {(DayOfWeekSpanish)@event.Date.DayOfWeek} {@event.Date.Day} de {(Month)@event.Date.Month} a las {@event.Date:HH:mm} UTC");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"📚Tema: {request.Event.Title}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"🎤Speaker: {request.Event.Speaker}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Así que no olviden registrarse 👇");
            stringBuilder.AppendLine("https://latinonet.online/links#registro");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Los esperamos! 😉");

            return _botMessageService.SendText(stringBuilder.ToString(),
                request.ChatId,
                request.ReplyToMessageId);
        }
    }
}
