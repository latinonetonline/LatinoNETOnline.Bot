using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Subscription.SubscribeUser
{
    public class SubscribeUserRequest : IRequest
    {
        public SubscribeUserRequest(long userId, int? replyToMessageId)
        {
            UserId = userId;
            ReplyToMessageId = replyToMessageId;
        }

        public long UserId { get; }
        public int? ReplyToMessageId { get; }
    }
}
