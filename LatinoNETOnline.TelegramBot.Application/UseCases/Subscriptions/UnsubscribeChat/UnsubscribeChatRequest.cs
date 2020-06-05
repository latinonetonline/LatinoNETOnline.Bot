
using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.UnsubscribeChat
{
    public class UnsubscribeChatRequest : IRequest
    {
        public UnsubscribeChatRequest(long chatId)
        {
            ChatId = chatId;
        }

        public long ChatId { get; }
    }
}
