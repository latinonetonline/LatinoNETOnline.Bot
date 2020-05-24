using System;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Services.Models;
using LatinoNETOnline.TelegramBot.Web.Services.Abstracts;

using Microsoft.AspNetCore.Mvc;

using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BroadcastMessagesController : ControllerBase
    {
        private readonly IBotService _botService;
        private readonly IEventService _service;

        public BroadcastMessagesController(IBotService botService, IEventService service)
        {
            _botService = botService;
            _service = service;
        }

        public async Task<IActionResult> SendNextEvent()
        {
            Event @event = await _service.GetNextEventAsync();

            Message msg = await _botService.Client.SendPhotoAsync(986536895,
                new FileToSend(new Uri(@event.ImageUrl)));

            await _botService.Client.SendTextMessageAsync(986536895,
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
                $"Para saber en que momento exacto empezamos visita https://latinonet.online" +
                Environment.NewLine +
                Environment.NewLine +
                $"Los esperamos! 😉",
                 ParseMode.Markdown,
                 replyToMessageId: msg.MessageId);

            return Ok();
        }
    }
}
