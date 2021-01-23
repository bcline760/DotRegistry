using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DotRegistry.Contract.Provider
{
    /// <summary>
    /// Represents a Terraform provider version used within the Terraform provider protocol for retrieving available versions.
    /// </summary>
    public class ProviderVersionEntity
    {
        /// <summary>
        /// The supported platforms for this provider version
        /// </summary>
        [JsonProperty("platforms", Required = Required.Always)]
        public List<ProviderPlatformEntity> Platforms { get; set; }

        /// <summary>
        /// The list of supported Terraform provider protocol versions
        /// </summary>
        [JsonProperty("protocols", Required = Required.Always)]
        public List<string> Protocols { get; set; }

        /// <summary>
        /// A published version of a Terraform provider
        /// </summary>
        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }
    }
}
