
using Dapper.Contrib.Extensions;

namespace LatinoNETOnline.TelegramBot.Infrastructure.DataAccess.Entities
{
    [Table("SubscribedChats")]
    public class SubscribedChat : Domain.SubscribedChat
    {
        [ExplicitKey]
        public override long ChatId { get; set; }
    }
}
