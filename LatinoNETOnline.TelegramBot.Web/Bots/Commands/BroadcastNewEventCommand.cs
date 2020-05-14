using System;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Services.Models;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Web.Bots.Commands
{
    public class NewEventCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class BroadcastNewEventCommand : CommandBase<NewEventCommandArgs>
    {
        private readonly IEventService _service;

        public BroadcastNewEventCommand(IEventService service) : base("broadcastnewevent")
        {
            _service = service;
        }

        public override async Task<UpdateHandlingResult> HandleCommand(Update update, NewEventCommandArgs args)
        {
            if (update.Message.Chat.Id == 986536895)
            {
                Event @event = await _service.GetNextEventAsync();

                Message msg = await Bot.Client.SendPhotoAsync(-484660283,
                    new FileToSend(new Uri(@event.ImageUrl)));

                await Bot.Client.SendTextMessageAsync(-484660283,
                    @"🚨*Nuevo Evento*🚨" +
                    Environment.NewLine +
                    "Les cuento que la comunidad Latino .NET Online realizará un nuevo Webinar." +
                    Environment.NewLine +
                    $"🕔Cuando: {@event.Date.ToLongDateString()}" +
                    Environment.NewLine +
                    $"📚Tema: {@event.Title}" +
                    Environment.NewLine +
                    $"🎤Speaker: {@event.Speaker}" +
                    Environment.NewLine +
                    $"🖥Donde: https://latinonet.online/live" +
                    Environment.NewLine +
                    $"Para saber en que momento exacto empezamos síguenos en Twitter https://twitter.com/LatinoNETOnline" +
                    Environment.NewLine +
                    $"Los esperamos! 😉",
                     ParseMode.Markdown,
                     replyToMessageId: msg.MessageId);

                await Bot.Client.SendTextMessageAsync(
                -update.Message.Chat.Id,
                "Broadcast enviado con exito!!",
                ParseMode.Markdown,
                replyToMessageId: update.Message.MessageId);
            }
            else
            {
                await Bot.Client.SendTextMessageAsync(
                -update.Message.Chat.Id,
                "No estas autorizado para realizar esta acción",
                ParseMode.Markdown,
                replyToMessageId: update.Message.MessageId);
            }

            return UpdateHandlingResult.Continue;
        }
    }
}
