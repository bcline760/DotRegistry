using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DotRegistry.Contract
{
    /// <summary>
    /// Defines a set of properties outlining a Terraform provider
    /// </summary>
    public abstract class Provider : EntityContract
    {
        /// <summary>
        /// 
        /// </summary>
        protected Provider()
        {

        }

        /// <summary>
        /// The namespace portion of the address of the requested provider. This is usually your company name or GitHub domain
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "ns")]
        public string Namespace { get; set; }

        /// <summary>
        /// An array of Terraform provider API versions that the provider supports, in the same format as for List Available Versions.
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "protocols")]
        public List<string> Protocols { get; set; }

        /// <summary>
        /// The type portion of the address of the requested provider. This is the name of your provider
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "version")]
        public string ProviderVersion { get; set; }
    }
}
