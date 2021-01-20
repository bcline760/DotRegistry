namespace DotRegistry.Model.GitHub
{
    using System;
    using Newtonsoft.Json;

    public partial class GitHubRepositoryLicenseModel
    {
        [JsonProperty("key", Required = Required.Always)]
        public string Key { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("spdx_id", Required = Required.Always)]
        public string SpdxId { get; set; }

        [JsonProperty("url", Required = Required.AllowNull)]
        public Uri Url { get; set; }

        [JsonProperty("node_id", Required = Required.Always)]
        public string NodeId { get; set; }
    }
}
