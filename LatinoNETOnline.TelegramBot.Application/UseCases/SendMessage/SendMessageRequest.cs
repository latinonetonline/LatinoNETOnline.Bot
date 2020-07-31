using System;
using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.SendMessage
{
    public class SendMessageRequest : IRequest
    {
        public SendMessageRequest(string message, Uri imageLink)
        {
            Message = message;
            ImageLink = imageLink;
        }

        public string Message { get; }
        public Uri ImageLink { get; }
    }
}
