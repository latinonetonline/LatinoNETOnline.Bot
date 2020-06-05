using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Dapper;
using Dapper.Contrib.Extensions;

using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Domain;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace LatinoNETOnline.TelegramBot.Infrastructure.DataAccess.Repositories
{
    public class SubscribedChatRepository : ISubscribedChatRepository
    {
        private readonly IDbConnection _db;
        public SubscribedChatRepository(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("Default"));
            SqlMapperExtensions.TableNameMapper = (type) => $"\"{type.Name}s\"";
        }
        public Task Delete(SubscribedChat subscribedUser)
        {
            return _db.DeleteAsync((Entities.SubscribedChat)subscribedUser);
        }

        public async Task<IEnumerable<SubscribedChat>> GetAll()
        {
            return await _db.GetAllAsync<Entities.SubscribedChat>();
        }

        public async Task<SubscribedChat> GetById(long userId)
        {
            return await _db.QuerySingleOrDefaultAsync<Entities.SubscribedChat>($"SELECT * FROM \"public\".\"{nameof(SubscribedChat)}s\" WHERE \"{nameof(SubscribedChat.ChatId)}\" = '{userId}'");
        }

        public Task Insert(SubscribedChat subscribedUser)
        {
            return _db.InsertAsync(subscribedUser);
        }

        public async Task<SubscribedChat> OpenSubscribedUser()
        {
            return await Task.Factory.StartNew(() => new Entities.SubscribedChat());
        }
    }
}
