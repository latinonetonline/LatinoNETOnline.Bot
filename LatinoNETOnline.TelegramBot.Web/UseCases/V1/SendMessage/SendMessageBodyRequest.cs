using System.Collections.Generic;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.SendMessage
{
    public class SendMessageBodyRequest
    {
        public string Message { get; set; }
        public string ImageLink { get; set; }
        public IEnumerable<long> Chats { get; set; }
    }
}
