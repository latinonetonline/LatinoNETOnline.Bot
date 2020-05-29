using System;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Infrastructure.Services
{
    public class BotMessageService : IBotMessageService
    {
        private readonly IBot _bot;

        public BotMessageService(IBotManager<LatinoNetOnlineTelegramBot> botManager)
        {
            _bot = ((BotManager<LatinoNetOnlineTelegramBot>)botManager).Bot;
        }

        public async Task<int> SendImage(Uri imageUri, long chatId, int? replyToMessageId)
        {
            Message msg = await _bot.Client.SendPhotoAsync(
                chatId,
                new FileToSend(imageUri),
                replyToMessageId: replyToMessageId.GetValueOrDefault());

            return msg.MessageId;
        }

        public async Task<int> SendText(string messageText, long chatId, int? replyToMessageId)
        {
            Message msg = await _bot.Client.SendTextMessageAsync(chatId,
                messageText,
                 ParseMode.Markdown,
                 replyToMessageId: replyToMessageId.GetValueOrDefault());

            return msg.MessageId;
        }
    }
}
