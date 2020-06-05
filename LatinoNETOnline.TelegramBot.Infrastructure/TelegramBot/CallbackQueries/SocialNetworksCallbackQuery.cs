using System.Threading.Tasks;

using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.CallbackQueries
{
    public class SocialNetworksCallbackQuery : IUpdateHandler
    {
        public bool CanHandleUpdate(IBot bot, Update update)
        {
            return update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQueryUpdate && update?.CallbackQuery?.Data == CallbackQueryConst.SOCIALNETWORKS;
        }

        public async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                    new []
                    {
                        InlineKeyboardButton.WithUrl("Twitter 🐤", "https://twitter.com/latinonetonline"),
                        InlineKeyboardButton.WithUrl("Youtube 🎬", "https://www.youtube.com/channel/UCR173iRDyQXcfkRWZ77gtaA"),
                        InlineKeyboardButton.WithUrl("Sitio Web 🌎", "https://latinonet.online/"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithUrl("Whatsapp 📱", "https://latinonet.online/links#wsp"),
                        InlineKeyboardButton.WithUrl("Telegram ✈", "https://latinonet.online/links#telegram")
                    }
                });
            await bot.Client.SendTextMessageAsync(
                chatId: update.CallbackQuery.Message.Chat.Id,
                text: "Nuestras Redes 👇",
                replyMarkup: inlineKeyboard
            );

            return UpdateHandlingResult.Continue;
        }
    }
}
