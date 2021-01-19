using System.Collections.Generic;
using System.Linq;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using DotRegistry.Contract;

namespace DotRegistry.Model
{
    public class SigningKeyModel
    {
        public SigningKeyModel()
        {
        }

        public SigningKeyModel(SigningKeys keys)
        {
            Keys = keys.GpgPublicKeys
                .Select(k => new GpgSigningKeyModel(k.KeyId, k.AsciiArmor))
                .ToList();
        }

        /// <summary>
        /// an array of objects, each describing one GPG signing key that is allowed to sign the checksums for this provider version.
        /// At least one element must be included, representing the key that produced the signature at shasums_signature_url.
        /// </summary>
        [BsonElement("gpg_public_keys"), BsonRequired]
        public List<GpgSigningKeyModel> Keys { get; set; }
    }
}
