using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Telegram.Bot.Framework;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.Bot.Web.Bots
{
    public class LatinoNETOnlineTelegramBot : BotBase<LatinoNETOnlineTelegramBot>
    {
        private readonly ILogger<LatinoNETOnlineTelegramBot> _logger;

        public LatinoNETOnlineTelegramBot(IOptions<BotOptions<LatinoNETOnlineTelegramBot>> botOptions, ILogger<LatinoNETOnlineTelegramBot> logger)
            : base(botOptions)
        {
            _logger = logger;
        }

        public override async Task HandleUnknownUpdate(Update update)
        {
            _logger.LogWarning("Unable to handle an update");

            const string unknownUpdateText = "Sorry! I don't know what to do with this message";

            if (update.Type == UpdateType.MessageUpdate)
            {
                await Client.SendTextMessageAsync(update.Message.Chat.Id,
                    unknownUpdateText,
                    replyToMessageId: update.Message.MessageId);
            }

        }

        public override Task HandleFaultedUpdate(Update update, Exception e)
        {
            _logger.LogCritical("Exception thrown while handling an update");
            return Task.CompletedTask;
        }
    }
}
