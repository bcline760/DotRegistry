namespace DotRegistry.Model.GitHub
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GitHubReleaseModel
    {
        [JsonProperty("url", Required = Required.Always)]
        public Uri Url { get; set; }

        [JsonProperty("assets_url", Required = Required.Always)]
        public Uri AssetsUrl { get; set; }

        [JsonProperty("upload_url", Required = Required.Always)]
        public string UploadUrl { get; set; }

        [JsonProperty("html_url", Required = Required.Always)]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("author", Required = Required.Always)]
        public GitHubReleaseAuthorModel Author { get; set; }

        [JsonProperty("node_id", Required = Required.Always)]
        public string NodeId { get; set; }

        [JsonProperty("tag_name", Required = Required.Always)]
        public string TagName { get; set; }

        [JsonProperty("target_commitish", Required = Required.Always)]
        public string TargetCommitish { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("draft", Required = Required.Always)]
        public bool Draft { get; set; }

        [JsonProperty("prerelease", Required = Required.Always)]
        public bool Prerelease { get; set; }

        [JsonProperty("created_at", Required = Required.Always)]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("published_at", Required = Required.Always)]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("assets", Required = Required.Always)]
        public List<GitHubReleaseAssetModel> Assets { get; set; }

        [JsonProperty("tarball_url", Required = Required.Always)]
        public Uri TarballUrl { get; set; }

        [JsonProperty("zipball_url", Required = Required.Always)]
        public Uri ZipballUrl { get; set; }

        [JsonProperty("body", Required = Required.Always)]
        public string Body { get; set; }
    }
}
