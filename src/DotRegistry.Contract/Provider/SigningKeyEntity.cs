using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace DotRegistry.Contract.Provider
{
    public class SigningKeyEntity
    {
        /// <summary>
        /// an array of objects, each describing one GPG signing key that is allowed to sign the checksums for this provider version.
        /// At least one element must be included, representing the key that produced the signature at shasums_signature_url.
        /// </summary>
        [JsonProperty("gpg_public_keys"), JsonRequired]
        public List<GpgSigningKeyEntity> Keys { get; set; }
    }
}
