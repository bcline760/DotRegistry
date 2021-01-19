using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DotRegistry.Core
{
    public static class StringExtensions
    {
        public static readonly JsonSerializerSettings JsonSerializeSettings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        /// <summary>
        /// Get upto the first eight characters of a string. If less than 8, then returns the string
        /// </summary>
        /// <param name="lhs"></param>
        /// <returns>Up to the first eight characters of the string</returns>
        public static string FirstEight(this string lhs)
        {
            return string.IsNullOrEmpty(lhs) && lhs.Length <= 8 ? lhs : lhs.Substring(0, 8);
        }

        public static string MakeSlug(this string[] props)
        {
            if (props.Any(p => p == null))
                throw new ArgumentNullException(nameof(props), "A given property for making a slug was null");

            //If it's an array of one, just call the method below.
            if (props.Length == 1)
                return props.First().MakeSlug();

            return props.Aggregate((c, n) => c.MakeSlug() + "-" + n.MakeSlug());
        }

        public static string MakeSlug(this string prop)
        {
            prop = prop.ToLower();

            return prop;
        }

        /// <summary>
        /// Serialize a list object to JSON
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="self">The </param>
        /// <returns>A JSON string representing the serialized objects</returns>
        public static string ToJson<T>(this List<T> self) => JsonConvert.SerializeObject(self, JsonSerializeSettings);

        /// <summary>
        /// Serialize a JSON object to string
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="self"></param>
        /// <returns>A JSON string representing the serialized object</returns>
        public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self, JsonSerializeSettings);
    }
}
