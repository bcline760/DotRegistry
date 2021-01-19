using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using DotRegistry.Contract;

namespace DotRegistry.Model
{
    public class GpgSigningKeyModel
    {
        public GpgSigningKeyModel()
        {

        }

        public GpgSigningKeyModel(GpgPublicKey key)
        {
            KeyId = key.KeyId;
            ArmoredPublicKey = key.AsciiArmor;
        }

        public GpgSigningKeyModel(string keyId, string armor)
        {
            KeyId = keyId;
            ArmoredPublicKey = armor;
        }

        /// <summary>
        /// 
        /// </summary>
        [BsonElement("key_id"), BsonRequired]
        public string KeyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BsonElement("ascii_armor"), BsonRequired]
        public string ArmoredPublicKey { get; set; }
    }
}
