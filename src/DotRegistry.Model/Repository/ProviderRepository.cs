using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using DotRegistry.Contract.Provider;
using DotRegistry.Interface.Repository;
using DotRegistry.Model.Provider;

using log4net;

using MongoDB.Driver;

namespace DotRegistry.Model.Repository
{
    public class ProviderRepository : DbRepository<ProviderEntity, ProviderModel>, IProviderRepository
    {
        public ProviderRepository(IMongoDatabase db, IMapper map, ILog log) : base(db, map, log)
        {
        }

        public async Task<ProviderEntity> GetProviderAsync(string nSpace, string name)
        {
            var filter = Builders<ProviderModel>.Filter.And(
                Builders<ProviderModel>.Filter.Eq("namespace", nSpace),
                Builders<ProviderModel>.Filter.Eq("name", name)
            );

            using (var result = await Collection.FindAsync(filter))
            {
                var doc = await result.FirstOrDefaultAsync();
                var map = Mapper.Map<ProviderEntity>(doc);

                return map;
            }
        }

        public async Task<List<ProviderEntity>> GetProvidersByPublishingUser(string publishedBySlug)
        {
            var filter = Builders<ProviderModel>.Filter.Eq("published_by", publishedBySlug);

            var providers = new List<ProviderEntity>();
            using (var result = await Collection.FindAsync(filter))
            {
                var models = await result.ToListAsync();
                providers.AddRange(Mapper.Map<List<ProviderEntity>>(models));

                return providers;
            }
        }
    }
}
