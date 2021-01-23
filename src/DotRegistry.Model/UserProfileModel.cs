using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotRegistry.Model
{
    public class UserProfileModel : DotRegistryModel
    {
        [BsonElement("email"), BsonRequired]
        public string EmailAddress { get; set; }

        [BsonElement("location"), BsonRequired]
        public string Location { get; set; }

        [BsonElement("published_modules"), BsonRequired]
        public List<string> PublishedModuleSlugs { get; set; }

        [BsonElement("published_providers"), BsonRequired]
        public List<string> PublishedProviderSlugs { get; set; }

        [BsonElement("signing_keys"), BsonRequired]
        public List<UserGpgKeyModel> SigningKeys { get; set; }
    }
}
