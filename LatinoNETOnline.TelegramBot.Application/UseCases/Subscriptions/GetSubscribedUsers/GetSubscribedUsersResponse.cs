using System.Collections.Generic;

using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.GetSubscribedUsers
{
    public class GetSubscribedUsersResponse
    {
        public IEnumerable<SubscribedUser> SubscribedUsers { get; set; }
    }
}
