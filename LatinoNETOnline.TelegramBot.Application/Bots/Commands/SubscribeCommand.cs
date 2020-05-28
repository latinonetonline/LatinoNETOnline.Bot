using System;
using System.Threading.Tasks;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Application.Bots.Commands
{
    public class SubscribeCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class SubscribeCommand : CommandBase<SubscribeCommandArgs>
    {
        public SubscribeCommand() : base("subscribirme")
        {

        }
        public override async Task<UpdateHandlingResult> HandleCommand(Update update, SubscribeCommandArgs args)
        {
            var userIdToSubscribe = update.Message.From.Id;

            await Bot.Client.SendTextMessageAsync(userIdToSubscribe, @"🎉 *Bienvenido/a* 🎉" +
                    Environment.NewLine +
                    Environment.NewLine +
                    "Nos alegra que te hayas suscrito al bot de Latino .NET Online 🤖" +
                    Environment.NewLine +
                    Environment.NewLine +
                    $"A partir de ahora recibirás todas las noticias de la comunidad." +
                    Environment.NewLine +
                    Environment.NewLine +
                    $"Estarás al tanto de los anuncios y recordatorios de nuestros próximos webinars📲, te  avisaremos cuando haya un nuevo artículo en nuestro blog, estarás al tanto de eventos de otras comunidades🤝🏻, y más! Todo en este mismo chat.",
                     ParseMode.Markdown);
            return UpdateHandlingResult.Continue;
        }
    }
}
