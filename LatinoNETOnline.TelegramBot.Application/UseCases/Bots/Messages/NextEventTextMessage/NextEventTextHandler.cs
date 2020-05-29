using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Bots;

using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.NextEventTextMessage
{
    public class NextEventTextHandler : AsyncBotMessageHandlerBase<NextEventTextRequest>
    {
        public NextEventTextHandler(IBotManager<LatinoNetOnlineTelegramBot> botManager) : base(botManager)
        { }

        protected override Task Handle(NextEventTextRequest request, CancellationToken cancellationToken)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("🚨 *Proximo Evento* 🚨");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"🕔Cuando: {request.Event.Date.ToLongDateString()}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"📚Tema: {request.Event.Title}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"🎤Speaker: {request.Event.Speaker}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Así que no olviden registrarse 👇");
            stringBuilder.AppendLine("https://latinonet.online/links#registro");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Los esperamos! 😉");

            return Bot.Client.SendTextMessageAsync(request.ChatId,
                stringBuilder.ToString(),
                 ParseMode.Markdown,
                 replyToMessageId: request.ReplyToMessageId);
        }
    }
}
