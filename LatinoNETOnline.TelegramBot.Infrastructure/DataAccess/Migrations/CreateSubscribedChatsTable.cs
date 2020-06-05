
using FluentMigrator;

using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Infrastructure.DataAccess.Migrations
{
    [Migration(050620200020)]
    public class CreateSubscribedChatsTable : Migration
    {
        public override void Up()
        {
            Create.Table($"{nameof(SubscribedChat)}s")
                .WithColumn(nameof(SubscribedChat.ChatId)).AsInt64().PrimaryKey();
        }

        public override void Down()
        {
            Delete.Table($"{nameof(SubscribedChat)}s");
        }
    }
}
