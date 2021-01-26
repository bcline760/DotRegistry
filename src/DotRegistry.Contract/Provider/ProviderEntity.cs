using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DotRegistry.Contract.Provider
{
    /// <summary>
    /// Defines a set of properties outlining a Terraform provider
    /// </summary>
    public class ProviderEntity : EntityContract
    {
        /// <summary>
        /// 
        /// </summary>
        public ProviderEntity()
        {

        }

        [JsonProperty(Required = Required.Always, PropertyName = "install_count")]

        public long InstallCount { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "last_published")]
        public DateTime LastPublished { get; set; }

        /// <summary>
        /// The namespace portion of the address of the requested provider. This is usually your company name or GitHub domain
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// An array of Terraform provider API versions that the provider supports, in the same format as for List Available Versions.
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "protocols")]
        public List<string> Protocols { get; set; }

        /// <summary>
        /// The type portion of the address of the requested provider. This is the name of your provider
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "id")]
        public string ProviderId { get; set; }

        /// <summary>
        /// The latest version of the provider
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "version")]
        public string ProviderVersion { get; set; }

        /// <summary>
        /// Get or set the person or organization that last published this provider
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "published_by_slug")]
        public string PublishedBySlug { get; set; }

        /// <summary>
        /// List of all packages available for this provider
        /// </summary>
        [JsonIgnore]
        public List<ProviderPackageEntity> Packages { get; set; }
    }
}
