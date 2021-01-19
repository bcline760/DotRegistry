using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotRegistry.Model
{
    /// <summary>
    /// Represents a platform object used in supplying available provider packages
    /// </summary>
    public class PlatformModel
    {
        /// <summary>
        /// Construct a new Platform Model
        /// </summary>
        public PlatformModel()
        {
        }

        /// <summary>
        /// Constuct a new Platform Model object
        /// </summary>
        /// <param name="arch">The CPU architecture</param>
        /// <param name="os">The supported OS</param>
        public PlatformModel(string arch, string os)
        {
            Architecture = arch;
            OperatingSystem = os;
        }

        /// <summary>
        /// Get or set the supported CPU architecture
        /// </summary>
        [BsonElement("arch"), BsonRequired]
        public string Architecture { get; set; }

        /// <summary>
        /// Get or set the supported operating system
        /// </summary>
        [BsonElement("os"), BsonRequired]
        public string OperatingSystem { get; set; }
    }
}
