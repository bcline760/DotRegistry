using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

using DotRegistry.Contract;
using DotRegistry.Model.Provider;

namespace DotRegistry.Model
{
    [BsonIgnoreExtraElements, BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(ProviderModel), typeof(UserProfileModel))]
    public abstract class DotRegistryModel
    {
        protected DotRegistryModel()
        {
        }

        protected DotRegistryModel(EntityContract contract)
        {
            Active = contract.Active;
            CreatedAt = contract.CreatedAt;
            Slug = contract.Slug;
            UpdatedAt = contract.UpdatedAt;
        }

        [BsonElement("active"), BsonRequired]
        public bool Active { get; set; }

        [BsonElement("created_at"), BsonRequired]
        public DateTime CreatedAt { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault, BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        public string Slug { get; set; }

#nullable enable
        [BsonElement("updated_at")]
        public DateTime? UpdatedAt { get; set; }
#nullable restore
    }
}
