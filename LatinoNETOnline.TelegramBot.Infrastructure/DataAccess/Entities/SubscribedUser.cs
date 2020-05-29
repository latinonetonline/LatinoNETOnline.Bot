
using Dapper.Contrib.Extensions;

namespace LatinoNETOnline.TelegramBot.Infrastructure.DataAccess.Entities
{
    [Table("SubscribedUsers")]
    public class SubscribedUser : Domain.SubscribedUser
    {
        [ExplicitKey]
        public override long UserId { get; set; }
    }
}
