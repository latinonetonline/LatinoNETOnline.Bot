using System.Collections.Generic;

using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.GetSubscribedChats
{
    public class GetSubscribedChatsResponse
    {
        public IEnumerable<SubscribedChat> SubscribedChats { get; set; }
    }
}
