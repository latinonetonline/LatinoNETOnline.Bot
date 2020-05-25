
using System.Threading.Tasks;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace LatinoNETOnline.TelegramBot.Web.Bots.Commands
{
    public class InfoCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }
    public class InfoCommand : CommandBase<InfoCommandArgs>
    {
        public InfoCommand() : base("info")
        {

        }
        public override async Task<UpdateHandlingResult> HandleCommand(Update update, InfoCommandArgs args)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Sobre Nosotros 🤝🏻", "sobrenosotros"),
                        InlineKeyboardButton.WithCallbackData("Nuestras redes 🖥", "nuestrasredes"),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Siguiente Evento 🎉", "siguienteevento"),
                        InlineKeyboardButton.WithUrl("Call For Speaker 🎤", "https://latinonet.online/links#callforspeaker"),
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
