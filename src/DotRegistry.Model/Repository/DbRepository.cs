using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using MongoDB.Driver;
using AutoMapper;
using log4net;

using DotRegistry.Core.Logging;
using DotRegistry.Contract;
using DotRegistry.Interface;

namespace DotRegistry.Model.Repository
{
    public abstract class DbRepository<TE, TM> : IRepository<TE>
        where TE : EntityContract, new()
        where TM : DotRegistryModel, new()
    {
        public DbRepository(IMongoDatabase db, IMapper map, ILog log)
        {
            string collectionName = GetCollectionName();
            Collection = db.GetCollection<TM>(collectionName);

            Mapper = map;
        }

        public virtual async Task DeleteAsync(string slug)
        {
            var record = await GetAsync(slug);

            if (record != null)
            {
                record.Active = false;
                record.UpdatedAt = DateTime.Now;

                await SaveAsync(record);
            }
        }

        public virtual async Task<IEnumerable<TE>> GetAllAsync()
        {

            List<TE> entities = new List<TE>();
            var filter = Builders<TM>.Filter.Empty;
            using (var collection = await Collection.FindAsync(filter))
            {
                var models = await collection.ToListAsync();
                entities.AddRange(Mapper.Map<List<TE>>(models));
            }

            return entities;
        }

        public virtual async Task<TE> GetAsync(string slug)
        {
            var filter = Builders<TM>.Filter.Eq("slug", slug);
            using (var result = await Collection.FindAsync(filter))
            {
                var doc = await result.FirstOrDefaultAsync();
                var map = Mapper.Map<TE>(doc);

                return map;
            }
        }

        public virtual async Task SaveAsync(TE entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrEmpty(entity.Slug))
                entity.Slugify();

            var model = Mapper.Map<TM>(entity);
            var filter = Builders<TM>.Filter.Eq("slug", model.Slug);
            var result = await Collection.ReplaceOneAsync(filter, model, new ReplaceOptions { IsUpsert = true });
        }

        /// <summary>
        /// Get the name of the collection based off the model. Will appropriatly pluralize
        /// </summary>
        /// <typeparam name="TM">The type of the model to use</typeparam>
        /// <returns>The name of the collection</returns>
        protected string GetCollectionName()
        {
            Type modelType = typeof(TM);
            string modelName = modelType.Name.Replace("Model", string.Empty);
            string collectionName = string.Empty;
            char endingCharacter = modelName[modelName.Length - 1];

            //Be smart about English
            if (char.ToLowerInvariant(endingCharacter) == 'y')
            {
                char nextChar = modelName[modelName.Length - 2];
                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                if (vowels.Any(v => v == nextChar))
                    collectionName = string.Concat(modelName, 's'); //bays, toys, keys
                else
                    collectionName = string.Concat(modelName.Substring(0, modelName.Length - 2), "ies"); //histories, flies, countries, etc.
            }
            else if (char.ToLowerInvariant(endingCharacter) == 'o') //Gonna have the odd case here...pianoes
            {
                collectionName = string.Concat(modelName, "es");
            }
            else
                collectionName = string.Concat(modelName, 's'); //Bows, Arrows

            Regex s_seperateWordRegex =
                            new Regex(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            return collectionName.ToLowerInvariant();
        }

        protected IMongoCollection<TM> Collection { get; }

        protected IMapper Mapper { get; }

        protected ILog Log { get; set; }
    }
}
