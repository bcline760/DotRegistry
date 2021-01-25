using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using DotRegistry.Contract.Provider;

namespace DotRegistry.Model.Provider
{
    public class GpgSigningKeyModel
    {
        public GpgSigningKeyModel()
        {

        }

        public GpgSigningKeyModel(GpgSigningKeyEntity key)
        {
            KeyId = key.KeyId;
            ArmoredPublicKey = key.ArmoredPublicKey;
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
