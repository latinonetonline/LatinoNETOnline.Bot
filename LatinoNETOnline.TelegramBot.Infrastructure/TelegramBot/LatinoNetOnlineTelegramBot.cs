﻿using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Telegram.Bot.Framework;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot
{
    public class LatinoNetOnlineTelegramBot : BotBase<LatinoNetOnlineTelegramBot>
    {
        private readonly ILogger<LatinoNetOnlineTelegramBot> _logger;

        public LatinoNetOnlineTelegramBot(IOptions<BotOptions<LatinoNetOnlineTelegramBot>> botOptions, ILogger<LatinoNetOnlineTelegramBot> logger)
            : base(botOptions)
        {
            _logger = logger;
        }

        public override async Task HandleUnknownUpdate(Update update)
        {
            _logger.LogWarning("Unable to handle an update");

            if (update.Type == UpdateType.MessageUpdate)
            {
                //await Client.SendTextMessageAsync(update.Message.Chat.Id,
                //    unknownUpdateText,
                //    replyToMessageId: update.Message.MessageId);
            }
        }

        public override Task HandleFaultedUpdate(Update update, Exception e)
        {
            _logger.LogCritical("Exception thrown while handling an update");
            return Task.CompletedTask;
        }
    }
}
