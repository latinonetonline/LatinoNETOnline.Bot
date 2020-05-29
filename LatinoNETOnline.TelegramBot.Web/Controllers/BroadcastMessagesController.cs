using System;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Bots;

using LatinoNETOnline.TelegramBot.Application.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.NextEventImageMessage;
using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.NextEventTextMessage;

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

            return Ok();
        }
    }
}
