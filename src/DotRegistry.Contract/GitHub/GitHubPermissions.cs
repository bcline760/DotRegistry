﻿namespace DotRegistry.Contract.GitHub
{

    using Newtonsoft.Json;

    public partial class GitHubPermissions
    {
        [JsonProperty("admin", Required = Required.Always)]
        public bool Admin { get; set; }

        [JsonProperty("push", Required = Required.Always)]
        public bool Push { get; set; }

        [JsonProperty("pull", Required = Required.Always)]
        public bool Pull { get; set; }
    }
}
