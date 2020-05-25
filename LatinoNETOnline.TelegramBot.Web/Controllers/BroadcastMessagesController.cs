using System;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Services.Abstracts;
using LatinoNETOnline.TelegramBot.Services.Models;
using LatinoNETOnline.TelegramBot.Web.Bots;

using Microsoft.AspNetCore.Mvc;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace LatinoNETOnline.TelegramBot.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BroadcastMessagesController : ControllerBase
    {
        private readonly BotManager<LatinoNetOnlineTelegramBot> _botService;
        private readonly IEventService _service;

        public BroadcastMessagesController(IBotManager<LatinoNetOnlineTelegramBot> botService, IEventService service)
        {
            _botService = (BotManager<LatinoNetOnlineTelegramBot>)botService;
            _service = service;
        }

        public async Task<IActionResult> SendNextEvent()
        {
            Event @event = await _service.GetNextEventAsync();

            Message msg = await _botService.Bot.Client.SendPhotoAsync(986536895,
                new FileToSend(new Uri(@event.ImageUrl)));

            await _botService.Bot.Client.SendTextMessageAsync(986536895,
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
