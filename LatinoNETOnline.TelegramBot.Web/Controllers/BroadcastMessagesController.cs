using System;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Bots;
using LatinoNETOnline.TelegramBot.Application.Mediators.Bots.Messages.NextEventImageMessage;
using LatinoNETOnline.TelegramBot.Application.Mediators.Bots.Messages.NextEventTextMessage;
using LatinoNETOnline.TelegramBot.Application.Services.Abstracts;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;

namespace LatinoNETOnline.TelegramBot.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class BroadcastMessagesController : BaseController
    {
        private readonly BotManager<LatinoNetOnlineTelegramBot> _botService;
        private readonly IEventService _service;

        public BroadcastMessagesController(IBotManager<LatinoNetOnlineTelegramBot> botService, IEventService service, IMediator mediator) : base(mediator)
        {
            _botService = (BotManager<LatinoNetOnlineTelegramBot>)botService;
            _service = service;
        }

        public async Task<IActionResult> SendNextEvent()
        {
            var @event = await _service.GetNextEventAsync();

            var nextEventImageRequest = new NextEventImageRequest(986536895, new Uri(@event.ImageUrl), null);

            var nextEventImageResponse = await Mediator.Send(nextEventImageRequest);

            var nextEventTextRequest = new NextEventTextRequest(986536895, nextEventImageResponse.MessageId, @event);

            await Mediator.Send(nextEventTextRequest);

            //Message msg = await _botService.Bot.Client.SendPhotoAsync(986536895,
            //    new FileToSend(new Uri(@event.ImageUrl)));

            //await _botService.Bot.Client.SendTextMessageAsync(986536895,
            //    @"🚨 *Proximo Evento* 🚨" +
            //    Environment.NewLine +
            //    Environment.NewLine +
            //    $"🕔Cuando: {@event.Date.ToLongDateString()}" +
            //    Environment.NewLine +
            //    Environment.NewLine +
            //    $"📚Tema: {@event.Title}" +
            //    Environment.NewLine +
            //    Environment.NewLine +
            //    $"🎤Speaker: {@event.Speaker}" +
            //    Environment.NewLine +
            //    Environment.NewLine +
            //    $"🖥Donde: https://latinonet.online/live" +
            //    Environment.NewLine +
            //    Environment.NewLine +
            //    $"Para saber en que momento exacto empezamos visita https://latinonet.online" +
            //    Environment.NewLine +
            //    Environment.NewLine +
            //    $"Los esperamos! 😉",
            //     ParseMode.Markdown,
            //     replyToMessageId: msg.MessageId);

            return Ok();
        }
    }
}
