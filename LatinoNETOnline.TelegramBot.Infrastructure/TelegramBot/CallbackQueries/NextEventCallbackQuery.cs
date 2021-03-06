﻿using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Messages.SendNextEvent;

using MediatR;


using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.CallbackQueries
{
    public class NextEventCallbackQuery : IUpdateHandler
    {
        private readonly IMediator _mediator;

        public NextEventCallbackQuery(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool CanHandleUpdate(IBot bot, Update update)
        {
            return update.Type == UpdateType.CallbackQueryUpdate && update?.CallbackQuery?.Data == CallbackQueryConst.NEXTEVENT;
        }

        public async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            SendNextEventRequest request = new SendNextEventRequest(update.CallbackQuery.Message.Chat.Id, null);
            await _mediator.Send(request);

            return UpdateHandlingResult.Continue;
        }
    }
}
