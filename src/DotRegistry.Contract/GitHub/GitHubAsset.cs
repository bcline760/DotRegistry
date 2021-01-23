namespace DotRegistry.Contract.GitHub
{
    using System;

    using Newtonsoft.Json;

    public partial class GitHubAsset
    {
        [JsonProperty("url", Required = Required.Always)]
        public Uri Url { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("node_id", Required = Required.Always)]
        public string NodeId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("label", Required = Required.Always)]
        public string Label { get; set; }

        [JsonProperty("uploader", Required = Required.Always)]
        public GitHubAuthor Uploader { get; set; }

        [JsonProperty("content_type", Required = Required.Always)]
        public string ContentType { get; set; }

        [JsonProperty("state", Required = Required.Always)]
        public string State { get; set; }

        [JsonProperty("size", Required = Required.Always)]
        public long Size { get; set; }

        [JsonProperty("download_count", Required = Required.Always)]
        public long DownloadCount { get; set; }

        [JsonProperty("created_at", Required = Required.Always)]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at", Required = Required.Always)]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("browser_download_url", Required = Required.Always)]
        public Uri BrowserDownloadUrl { get; set; }
    }
}
