using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Bson.Serialization.Attributes;

namespace DotRegistry.Model
{
    public class UserGpgKeyModel
    {
        [BsonElement("date_added"), BsonRequired]
        public DateTime DateAdded { get; set; }

        [BsonElement("key_id"), BsonRequired]
        public string KeyId { get; set; }

        [BsonElement("public_key"), BsonRequired]
        public string GpgPublicKey { get; set; }

        [BsonElement("namespace"), BsonRequired]
        public string Namespace { get; set; }
    }
}
