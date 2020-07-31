using System;
using System.Collections.Generic;
using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.SendMessage
{
    public class SendMessageRequest : IRequest
    {
        public SendMessageRequest(string message, Uri imageLink, IEnumerable<long> chats)
        {
            Message = message;
            ImageLink = imageLink;
            Chats = chats;
        }

        public string Message { get; }
        public Uri ImageLink { get; }
        public IEnumerable<long> Chats { get; set; }
    }
}
