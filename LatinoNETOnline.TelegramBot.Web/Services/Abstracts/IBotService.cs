
using Telegram.Bot;

namespace LatinoNETOnline.TelegramBot.Web.Services.Abstracts
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}
