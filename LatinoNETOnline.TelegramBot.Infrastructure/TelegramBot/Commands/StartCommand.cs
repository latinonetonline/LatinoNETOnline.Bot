
using System.Threading.Tasks;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.Commands
{
    public class StartCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }
    public class StartCommand : CommandBase<StartCommandArgs>
    {
        public StartCommand() : base(CommandConsts.START)
        {

        }
        public override async Task<UpdateHandlingResult> HandleCommand(Update update, StartCommandArgs args)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Sobre Nosotros 🤝🏻", CallbackQueryConst.ABOUTUS),
                        InlineKeyboardButton.WithCallbackData("Nuestras redes 🖥", CallbackQueryConst.SOCIALNETWORKS),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Siguiente Evento 🎉", CallbackQueryConst.NEXTEVENT),
                        InlineKeyboardButton.WithCallbackData("Suscribirse 📝", "https://latinonet.online/links#callforspeaker"),
                    }
            });

            await Bot.Client.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Escoge",
                replyMarkup: inlineKeyboard
            );

            return UpdateHandlingResult.Continue;
        }
    }
}
