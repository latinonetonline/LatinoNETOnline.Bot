using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.SubscribeChat
{
    public class SubscribeChatRequest : IRequest
    {
        public SubscribeChatRequest(long chatId)
        {
            ChatId = chatId;
        }

        public long ChatId { get; }
    }
}
