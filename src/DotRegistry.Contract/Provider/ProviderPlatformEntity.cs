using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace DotRegistry.Contract.Provider
{
    /// <summary>
    /// Represents supported platforms of a provider version within the Terraform provider protocol.
    /// </summary>
    public class ProviderPlatformEntity
    {
        /// <summary>
        /// Supported architecture (CPU) for this provider version
        /// </summary>
        [JsonProperty("arch", Required = Required.Always)]
        public string Architecture { get; set; }

        /// <summary>
        /// Supported operating system for this provider version
        /// </summary>
        [JsonProperty("os", Required = Required.Always)]
        public string OperatingSystem { get; set; }
    }
}
