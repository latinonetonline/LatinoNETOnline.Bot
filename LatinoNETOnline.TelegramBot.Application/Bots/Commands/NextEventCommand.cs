using System;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Domain;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Application.Bots.Commands
{

    public class NextEventCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class NextEventCommand : CommandBase<NextEventCommandArgs>
    {
        private readonly IEventService _service;

        public NextEventCommand(IEventService service) : base("siguiente_evento")
        {
            _service = service;
        }

        public override async Task<UpdateHandlingResult> HandleCommand(Update update, NextEventCommandArgs args)
        {
            Event @event = await _service.GetNextEventAsync();
            if (@event.Date < DateTime.Now.ToUniversalTime())
            {
                await Bot.Client.SendTextMessageAsync(update.Message.Chat.Id, @"Por le momento no se ha cargado un nuevo evento.", replyToMessageId: update.Message.MessageId);
            }
            else
            {
                Message msg = await Bot.Client.SendPhotoAsync(update.Message.Chat.Id,
                new FileToSend(new Uri(@event.ImageUrl)), replyToMessageId: update.Message.MessageId);

                await Bot.Client.SendTextMessageAsync(update.Message.Chat.Id,
                    @"🚨 *Proximo Evento* 🚨" +
                    Environment.NewLine +
                    Environment.NewLine +
                    $"🕔Cuando: {@event.Date.ToLongDateString()}" +
                    Environment.NewLine +
                    Environment.NewLine +
                    $"📚Tema: {@event.Title}" +
                    Environment.NewLine +
                    Environment.NewLine +
                    $"🎤Speaker: {@event.Speaker}" +
                    Environment.NewLine +
                    Environment.NewLine +
                    $"🖥Donde: https://latinonet.online/live" +
                    Environment.NewLine +
                    Environment.NewLine +
                    $"Los esperamos! 😉",
                     ParseMode.Markdown,
                     replyToMessageId: msg.MessageId);



            }


            return UpdateHandlingResult.Continue;
        }
    }
}
