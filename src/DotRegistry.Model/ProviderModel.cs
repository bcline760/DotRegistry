using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using DotRegistry.Contract;

namespace DotRegistry.Model
{

    [BsonKnownTypes(typeof(ProviderPackageModel))]
    public abstract class ProviderModel : DotRegistryModel
    {
        protected ProviderModel()
        {

        }

        protected ProviderModel(Provider provider) : base(provider)
        {
            Namespace = provider.Namespace;
            Protocols = provider.Protocols;
            Type = provider.Type;
        }

        [BsonElement("namespace"), BsonRequired]
        public string Namespace { get; set; }

        /// <summary>
        /// An array of Terraform provider API versions that the provider supports, in the same format as for List Available Versions.
        /// </summary>
        [BsonElement("protocols"), BsonRequired]
        public List<string> Protocols { get; set; }

        [BsonElement("type"), BsonRequired]
        public string Type { get; set; }
    }
}
