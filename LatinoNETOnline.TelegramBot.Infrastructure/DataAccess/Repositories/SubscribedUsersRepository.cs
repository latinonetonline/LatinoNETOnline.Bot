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
    public class SubscribedUsersRepository : ISubscribedUsersRepository
    {
        private readonly IDbConnection _db;
        public SubscribedUsersRepository(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("Default"));
            SqlMapperExtensions.TableNameMapper = (type) => $"\"{type.Name}s\"";
        }
        public Task Delete(SubscribedUser subscribedUser)
        {
            return _db.DeleteAsync((Entities.SubscribedUser)subscribedUser);
        }

        public async Task<IEnumerable<SubscribedUser>> GetAll()
        {
            return await _db.GetAllAsync<Entities.SubscribedUser>();
        }

        public async Task<SubscribedUser> GetById(long userId)
        {
            return await _db.QuerySingleOrDefaultAsync<Entities.SubscribedUser>($"SELECT * FROM \"public\".\"SubscribedUsers\" WHERE \"{nameof(SubscribedUser.UserId)}\" = '{userId}'");
        }

        public Task Insert(SubscribedUser subscribedUser)
        {
            return _db.InsertAsync(subscribedUser);
        }

        public async Task<SubscribedUser> OpenSubscribedUser()
        {
            return await Task.Factory.StartNew(() => new Entities.SubscribedUser());
        }
    }
}
