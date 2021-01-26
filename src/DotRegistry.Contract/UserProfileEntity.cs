
using System.Collections.Generic;
using Newtonsoft.Json;

using DotRegistry.Core;
using DotRegistry.Contract.GitHub;

namespace DotRegistry.Contract
{
    public class UserProfileEntity : EntityContract
    {
        public UserProfileEntity()
        {

        }

        //
        // Summary:
        //     URL of the account's avatar.
        [JsonProperty("avatar", Required = Required.Always)]
        public string AvatarUrl { get; set; }

        //
        // Summary:
        //     The account's bio.
        [JsonProperty("bio", Required = Required.AllowNull)]
        public string Bio { get; set; }

        //
        // Summary:
        //     Company the account works for.
        [JsonProperty("company", Required = Required.AllowNull)]
        public string Company { get; set; }

        //
        // Summary:
        //     The account's email.
        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }

        //
        // Summary:
        //     The HTML URL for the account on github.com (or GitHub Enterprise).
        [JsonProperty("htmlUrl", Required = Required.Always)]
        public string HtmlUrl { get; set; }

        //
        // Summary:
        //     The account's geographic location.
        [JsonProperty("location", Required = Required.Always)]
        public string Location { get; set; }

        //
        // Summary:
        //     The account's login.
        [JsonProperty("login", Required = Required.Always)]
        public string Login { get; set; }

        //
        // Summary:
        //     The account's full name.
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        //
        // Summary:
        //     GraphQL Node Id
        [JsonProperty("nodeId", Required = Required.Always)]
        public string NodeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("", Required = Required.AllowNull)]
        public List<string> PublishedModuleSlugs { get; set; }

        /// <summary>
        /// Get or set the number of published
        /// </summary>
        [JsonProperty("", Required = Required.AllowNull)]
        public List<string> PublishedProviderSlugs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("signingKeys", Required = Required.Always)]
        public List<GitHubGpgKey> SigningKeys { get; set; }

        //
        // Summary:
        //     The account's API URL.
        [JsonProperty("url", Required = Required.Always)]
        public string Url { get; set; }

        [JsonIgnore]
        public override string[] SlugProperties
        {
            get
            {
                return new string[]
                {
                    Login,
                    NodeId.FirstEight()
                };
            }
        }
    }
}
