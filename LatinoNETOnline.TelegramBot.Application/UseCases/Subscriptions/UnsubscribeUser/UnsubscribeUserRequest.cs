
using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.UnsubscribeUser
{
    public class UnsubscribeUserRequest : IRequest
    {
        public UnsubscribeUserRequest(long userId, int? replyToMessageId)
        {
            UserId = userId;
            ReplyToMessageId = replyToMessageId;
        }

        public long UserId { get; }
        public int? ReplyToMessageId { get; }
    }
}
