using System;

using Newtonsoft.Json;

using DotRegistry.Core;

namespace DotRegistry.Contract
{
    public class GitHubUser : EntityContract
    {
        public GitHubUser()
        {
        }

        [JsonProperty("pat", Required = Required.Always)]

        public string PersonalAccessToken { get; set; }

        [JsonProperty("userame", Required = Required.Always)]
        public string Username { get; set; }

        [JsonIgnore]
        public override string[] SlugProperties => new string[] { Username, PersonalAccessToken.FirstEight() };
    }
}
