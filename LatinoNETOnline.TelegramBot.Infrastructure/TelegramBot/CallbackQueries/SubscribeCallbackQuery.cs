using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.SubscribeUser;

using MediatR;

using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot.CallbackQueries
{
    public class SubscribeCallbackQuery : IUpdateHandler
    {
        private readonly IMediator _mediator;

        public SubscribeCallbackQuery(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool CanHandleUpdate(IBot bot, Update update)
        {
            return update.Type == UpdateType.CallbackQueryUpdate && update?.CallbackQuery?.Data == CallbackQueryConst.SUBSCRIBE;
        }

        public async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            SubscribeUserRequest request = new SubscribeUserRequest(update.CallbackQuery.From.Id, update.CallbackQuery.From.FirstName, null);
            await _mediator.Send(request);

            return UpdateHandlingResult.Continue;
        }
    }
}
