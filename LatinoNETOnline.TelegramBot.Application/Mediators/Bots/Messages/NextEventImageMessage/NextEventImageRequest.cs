using System;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.Mediators.Bots.Messages.NextEventImageMessage
{
    public class NextEventImageRequest : IRequest<NextEventImageResponse>
    {
        public NextEventImageRequest(long chatId, Uri imageUri, int? replyToMessageId)
        {
            ChatId = chatId;
            ImageUri = imageUri;
            ReplyToMessageId = replyToMessageId;
        }

        public long ChatId { get; }
        public Uri ImageUri { get; }
        public int? ReplyToMessageId { get; }
    }
}
