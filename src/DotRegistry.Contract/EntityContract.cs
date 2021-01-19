using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

using DotRegistry.Core;

namespace DotRegistry.Contract
{
    [JsonObject(IsReference = true)]
    public abstract class EntityContract : ISluggable
    {
        /// <summary>
        /// Get or set whether this provider is active or not
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "active")]
        public bool Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonIgnore]
        public virtual string[] SlugProperties => throw new NotImplementedException();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.AllowNull, PropertyName = "updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
