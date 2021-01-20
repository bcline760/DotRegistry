namespace DotRegistry.Model.GitHub
{
    using System;
    using Newtonsoft.Json;

    public partial class GitHubRepositoryOwnerModel
    {
        [JsonProperty("login", Required = Required.Always)]
        public string Login { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("node_id", Required = Required.Always)]
        public string NodeId { get; set; }

        [JsonProperty("avatar_url", Required = Required.Always)]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("gravatar_id", Required = Required.Always)]
        public string GravatarId { get; set; }

        [JsonProperty("url", Required = Required.Always)]
        public Uri Url { get; set; }

        [JsonProperty("html_url", Required = Required.Always)]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("followers_url", Required = Required.Always)]
        public Uri FollowersUrl { get; set; }

        [JsonProperty("following_url", Required = Required.Always)]
        public string FollowingUrl { get; set; }

        [JsonProperty("gists_url", Required = Required.Always)]
        public string GistsUrl { get; set; }

        [JsonProperty("starred_url", Required = Required.Always)]
        public string StarredUrl { get; set; }

        [JsonProperty("subscriptions_url", Required = Required.Always)]
        public Uri SubscriptionsUrl { get; set; }

        [JsonProperty("organizations_url", Required = Required.Always)]
        public Uri OrganizationsUrl { get; set; }

        [JsonProperty("repos_url", Required = Required.Always)]
        public Uri ReposUrl { get; set; }

        [JsonProperty("events_url", Required = Required.Always)]
        public string EventsUrl { get; set; }

        [JsonProperty("received_events_url", Required = Required.Always)]
        public Uri ReceivedEventsUrl { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("site_admin", Required = Required.Always)]
        public bool SiteAdmin { get; set; }
    }
}
