using System;
using System.Threading.Tasks;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Web.Bots.Commands
{
    public class UnsubscribeCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class UnsubscribeCommand : CommandBase<UnsubscribeCommandArgs>
    {
        public UnsubscribeCommand() : base("desuscribirse")
        {

        }

        public override async Task<UpdateHandlingResult> HandleCommand(Update update, UnsubscribeCommandArgs args)
        {
            var userIdToSubscribe = update.Message.From.Id;

            await Bot.Client.SendTextMessageAsync(userIdToSubscribe, @"Es una pena que te vayas 😭" +
                    Environment.NewLine +
                    "Pero no olvides que siempre vas a poder subscribirte de nuevo",
                     ParseMode.Markdown);
            return UpdateHandlingResult.Continue;
        }
    }
}
