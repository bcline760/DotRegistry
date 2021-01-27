using System;
using System.Collections.Generic;

using DotRegistry.Model.Provider;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotRegistry.Model
{
    public class UserProfileModel : DotRegistryModel
    {
        [BsonElement("avatar_url"), BsonRequired]
        public string AvatarUrl { get; set; }

        [BsonElement("bio"), BsonRequired]
        public string Bio { get; set; }

        [BsonElement("company"), BsonRequired]
        public string Company { get; set; }

        [BsonElement("email"), BsonRequired]
        public string EmailAddress { get; set; }

        [BsonElement("html_url"), BsonRequired]
        public string HtmlUrl { get; set; }

        [BsonElement("location"), BsonRequired]
        public string Location { get; set; }

        [BsonElement("login"), BsonRequired]
        public string Login { get; set; }

        [BsonElement("name"), BsonRequired]
        public string Name { get; set; }

        [BsonElement("node_id"), BsonRequired]
        public string NodeId { get; set; }

        [BsonElement("published_modules"), BsonRequired]
        public List<string> PublishedModuleSlugs { get; set; }

        [BsonElement("published_providers"), BsonRequired]
        public List<string> PublishedProviderSlugs { get; set; }

        [BsonElement("signing_keys"), BsonRequired]
        public List<GpgSigningKeyModel> SigningKeys { get; set; }

        public string Url { get; set; }
    }
}
