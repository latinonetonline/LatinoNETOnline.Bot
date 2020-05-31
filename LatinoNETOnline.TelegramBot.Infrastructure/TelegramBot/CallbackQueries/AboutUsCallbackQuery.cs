using System.Text;
using System.Threading.Tasks;

using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.CallbackQueries
{
    public class AboutUsCallbackQuery : IUpdateHandler
    {
        public bool CanHandleUpdate(IBot bot, Update update)
        {
            return update.Type == UpdateType.CallbackQueryUpdate && update.CallbackQuery.Data == CallbackQueryConst.ABOUTUS;
        }

        public async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("*Latino .NET Online* tiene el objetivo de unir a todas las comunidades .NET de Latinoamérica, para esto los miembros de estas comunidades participan de los Webinars que realizamos todos los sábados con la meta de brindar otro espacio donde poder seguir aprendiendo en conjunto.");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("*Temas Vistos:*");
            stringBuilder.AppendLine("✔ Temas vinculados con .NET");
            stringBuilder.AppendLine("✔ Diseño y arquitectura de software");
            stringBuilder.AppendLine("✔ Herramientas y consejos para mejorar como desarrolladores");
            stringBuilder.AppendLine("✔ Bases de datos, clouds y otros");


            await bot.Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
                    stringBuilder.ToString());

            return UpdateHandlingResult.Continue;
        }
    }
}
