using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Subscription.SubscribeUser
{
    public class SubscribeUserRequest : IRequest
    {
        public SubscribeUserRequest(long userId, string userFirstName, int? replyToMessageId)
        {
            UserId = userId;
            UserFirstName = userFirstName;
            ReplyToMessageId = replyToMessageId;
        }

        public long UserId { get; }
        public string UserFirstName { get; }
        public int? ReplyToMessageId { get; }
    }
}
