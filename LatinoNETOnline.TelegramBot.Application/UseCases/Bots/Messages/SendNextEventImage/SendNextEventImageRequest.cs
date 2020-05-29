using System;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEventImage
{
    public class SendNextEventImageRequest : IRequest<SendNextEventImageResponse>
    {
        public SendNextEventImageRequest(long chatId, Uri imageUri, int? replyToMessageId)
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
