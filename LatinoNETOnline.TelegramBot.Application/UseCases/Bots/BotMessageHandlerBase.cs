using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Bots;

using MediatR;

using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots
{
    public abstract class BotMessageHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected BotMessageHandlerBase(IBotManager<LatinoNetOnlineTelegramBot> botManager)
        {
            Bot = ((BotManager<LatinoNetOnlineTelegramBot>)botManager).Bot;
        }

        protected IBot Bot { get; }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
