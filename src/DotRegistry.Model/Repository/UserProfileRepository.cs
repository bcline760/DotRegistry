using System.Threading.Tasks;

using AutoMapper;

using DotRegistry.Contract;
using DotRegistry.Interface.Repository;

using log4net;

using MongoDB.Driver;

namespace DotRegistry.Model.Repository
{
    public class UserProfileRepository : DbRepository<UserProfileEntity, UserProfileModel>, IUserProfileRepository
    {
        public UserProfileRepository(IMongoDatabase db, IMapper map, ILog log) : base(db, map, log)
        {
        }

        public async Task<UserProfileEntity> GetByLogin(string login)
        {
            var filter = Builders<UserProfileModel>.Filter.Eq("login", login);

            using (var result = await Collection.FindAsync(filter))
            {
                var doc = await result.FirstOrDefaultAsync();
                var map = Mapper.Map<UserProfileEntity>(doc);

                return map;
            }
        }
    }
}