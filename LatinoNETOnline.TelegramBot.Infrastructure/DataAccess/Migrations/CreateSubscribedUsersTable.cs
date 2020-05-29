
using FluentMigrator;

using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Infrastructure.DataAccess.Migrations
{
    [Migration(290520200905)]
    public class CreateSubscribedUsersTable : Migration
    {
        public override void Up()
        {
            Create.Table($"{nameof(SubscribedUser)}s")
                .WithColumn(nameof(SubscribedUser.UserId)).AsInt64().PrimaryKey();
        }

        public override void Down()
        {
            Delete.Table($"{nameof(SubscribedUser)}s");
        }
    }
}
