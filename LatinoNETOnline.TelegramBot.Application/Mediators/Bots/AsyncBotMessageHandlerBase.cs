
using LatinoNETOnline.TelegramBot.Application.Bots;

using MediatR;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;

namespace LatinoNETOnline.TelegramBot.Application.Mediators.Bots
{
    public abstract class AsyncBotMessageHandlerBase<TRequest> : AsyncRequestHandler<TRequest> where TRequest : IRequest
    {
        protected AsyncBotMessageHandlerBase(IBotManager<LatinoNetOnlineTelegramBot> botManager)
        {
            Bot = ((BotManager<LatinoNetOnlineTelegramBot>)botManager).Bot;
        }

        protected IBot Bot { get; }
    }
}
