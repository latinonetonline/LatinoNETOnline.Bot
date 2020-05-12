using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.Bot.Web.Commands
{

    public class NextEventCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class NextEventCommand : CommandBase<NextEventCommandArgs>
    {
        public NextEventCommand()
            : base("nextevent")
        {

        }
        public override async Task<UpdateHandlingResult> HandleCommand(Update update, NextEventCommandArgs args)
        {
            await Bot.Client.SendPhotoAsync(update.Message.Chat.Id, new FileToSend(new Uri("https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F100095944%2F433524742148%2F1%2Foriginal.20200504-035248?auto=format%2Ccompress&q=75&sharp=10&s=0272ac1231f32b3f9f7ff0232f37d853")), "Este es el siguente evento!!",
                replyToMessageId: update.Message.MessageId);

            await Bot.Client.SendTextMessageAsync(update.Message.Chat.Id, Guid.NewGuid().ToString(), replyToMessageId: update.Message.MessageId);

            return UpdateHandlingResult.Continue;
        }
    }
}
