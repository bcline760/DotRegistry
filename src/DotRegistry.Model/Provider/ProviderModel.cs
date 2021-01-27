using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotRegistry.Model.Provider
{
    public class ProviderModel : DotRegistryModel
    {
        [BsonElement("install_count"), BsonRequired]
        public long InstallCount { get; set; }

        [BsonElement("published"), BsonRequired]
        public DateTime LastPublished { get; set; }

        [BsonElement("name"), BsonRequired]
        public string Name { get; set; }

        [BsonElement("namespace"), BsonRequired]
        public string Namespace { get; set; }

        [BsonElement("packages"), BsonRequired]
        public List<ProviderPackageModel> Packages { get; set; }

        [BsonElement("id"), BsonRequired]
        public string ProviderId { get; set; }

        [BsonElement("published_by"), BsonRequired]
        public string PublishedBySlug { get; set; }
    }
}
