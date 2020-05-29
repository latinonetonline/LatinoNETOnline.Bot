
using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEvent
{
    public class SendNextEventRequest : IRequest
    {
        public SendNextEventRequest(long chatId, int? replyToMessageId)
        {
            ChatId = chatId;
            ReplyToMessageId = replyToMessageId;
        }

        public long ChatId { get; }
        public int? ReplyToMessageId { get; }
    }
}
