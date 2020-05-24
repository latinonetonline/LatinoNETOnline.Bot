
using LatinoNETOnline.TelegramBot.Web.Bots;
using LatinoNETOnline.TelegramBot.Web.Services.Abstracts;

using Microsoft.Extensions.Options;

using Telegram.Bot;
using Telegram.Bot.Framework;

namespace LatinoNETOnline.TelegramBot.Web.Services.Concretes
{
    public class BotService : IBotService
    {
        private readonly BotOptions<LatinoNetOnlineTelegramBot> _config;

        public BotService(IOptions<BotOptions<LatinoNetOnlineTelegramBot>> config)
        {
            _config = config.Value;
            Client = new TelegramBotClient(_config.ApiToken);
        }

        public TelegramBotClient Client { get; }
    }
}
