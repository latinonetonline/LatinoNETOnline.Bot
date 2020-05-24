using System;
using System.Threading.Tasks;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Web.Bots.Commands
{
    public class SubscribeCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class SubscribeCommand : CommandBase<SubscribeCommandArgs>
    {
        public SubscribeCommand() : base("suscribirse")
        {

        }
        public override async Task<UpdateHandlingResult> HandleCommand(Update update, SubscribeCommandArgs args)
        {
            var userIdToSubscribe = update.Message.From.Id;

            await Bot.Client.SendTextMessageAsync(userIdToSubscribe, @"🎉 *Bienvenido* 🎉" +
                    Environment.NewLine +
                    "Nos alegramos que te allas subscripto al bot de Latino .NET Online." +
                    Environment.NewLine +
                    $"A partir de ahora recibiras todas las noticias de la comunidad en este mismo chat." +
                    Environment.NewLine +
                    $"Por Ejemplo: Anuncios y recordatorios de nuestros webinars, te noticaremos cuando haya un nuevo artículo en nuestro blog, te haremos llegar eventos de otras comunidades, y más",
                     ParseMode.Markdown);
            return UpdateHandlingResult.Continue;
        }
    }
}
