using System;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Services.Models;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace LatinoNETOnline.TelegramBot.Web.Bots.Commands
{

    public class NextEventCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }

        public string ArgsInput { get; set; }
    }

    public class NextEventCommand : CommandBase<NextEventCommandArgs>
    {
        private readonly IEventService _service;

        public NextEventCommand(IEventService service) : base("nextevent")
        {
            _service = service;
        }

        public override async Task<UpdateHandlingResult> HandleCommand(Update update, NextEventCommandArgs args)
        {
            Event @event = await _service.GetNextEventAsync();

            await Bot.Client.SendPhotoAsync(update.Message.Chat.Id,
                new FileToSend(new Uri(@event.ImageUrl)),
                "Este es el siguente evento!!",
                replyToMessageId: update.Message.MessageId);

            return UpdateHandlingResult.Continue;
        }
    }
}
