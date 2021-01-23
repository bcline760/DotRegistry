using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace DotRegistry.Contract.Provider
{
    public class GpgSigningKeyEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("key_id"), JsonRequired]
        public string KeyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ascii_armor"), JsonRequired]
        public string ArmoredPublicKey { get; set; }
    }
}
