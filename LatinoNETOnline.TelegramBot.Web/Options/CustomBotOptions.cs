
using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;

namespace LatinoNETOnline.TelegramBot.Web.Options
{
    public class CustomBotOptions<TBot> : BotOptions<TBot> where TBot : class, IBot
    {
        public string WebhookDomain { get; set; }
    }
}
