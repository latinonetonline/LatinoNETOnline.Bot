using LatinoNETOnline.TelegramBot.Domain;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.NextEventTextMessage
{
    public class NextEventTextRequest : IRequest
    {
        public NextEventTextRequest(long chatId, int replyToMessageId, Event @event)
        {
            ChatId = chatId;
            ReplyToMessageId = replyToMessageId;
            Event = @event;
        }

        public long ChatId { get; }
        public int ReplyToMessageId { get; }
        public Event Event { get; }
    }
}
