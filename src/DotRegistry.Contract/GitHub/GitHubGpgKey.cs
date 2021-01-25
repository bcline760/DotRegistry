using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace DotRegistry.Contract.GitHub
{
    public class GitHubGpgKey
    {
        [JsonProperty("date_added"), JsonRequired]
        public DateTime DateAdded { get; set; }

        [JsonProperty("key_id"), JsonRequired]
        public string KeyId { get; set; }

        [JsonProperty("public_key"), JsonRequired]
        public string GpgPublicKey { get; set; }

        [JsonProperty("namespace"), JsonRequired]
        public string Namespace { get; set; }
    }
}
