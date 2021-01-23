using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace DotRegistry.Contract.Provider
{
    /// <summary>
    /// Represents a Terraform provider package which contains URL links and signature for the Terraform provider
    /// Terraform uses this on "terraform init" to download the provider binaries for the host machine and version
    /// </summary>
    public class ProviderPackageEntity
    {
        /// <summary>
        /// This must currently echo back the arch parameter from the request. Other possibilities may come in later versions of this protocol.
        /// </summary>
        [JsonProperty("arch", Required = Required.Always)]
        public string Architecture { get; set; }

        /// <summary>
        /// A URL from which Terraform can retrieve the provider's zip archive.
        /// If this is a relative URL then it will be resolved relative to the URL that returned the containing JSON object.
        /// </summary>
        [JsonProperty("download_url", Required = Required.Always)]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// The filename for this provider's zip archive as recorded in the "shasums" document,
        /// so that Terraform CLI can determine which of the given checksums should be used for this specific package.
        /// </summary>
        [JsonProperty("filename", Required = Required.Always)]
        public string Filename { get; set; }

        /// <summary>
        /// This must currently echo back the os parameter from the request.
        /// Other possibilities may come in later versions of this protocol.
        /// </summary>
        [JsonProperty("os", Required = Required.Always)]
        public string OperatingSystem { get; set; }

        /// <summary>
        /// The list of supported Terraform provider protocol versions
        /// </summary>
        [JsonProperty("protocols", Required = Required.Always)]
        public List<string> Protocols { get; set; }

        /// <summary>
        /// An object describing signing keys for this provider package, one of which must have been used to produce the signature at shasums_signature_url.
        /// </summary>
        [JsonProperty("signing_keys", Required = Required.Always)]
        public SigningKeyEntity SigningKey { get; set; }

        /// <summary>
        /// The SHA256 Hash of the provider binary
        /// </summary>
        [JsonProperty("shasum", Required = Required.Always)]
        public string ShaSum { get; set; }

        /// <summary>
        /// A URL from which Terraform can retrieve a binary, detached GPG signature for the document at shasums_url,
        /// signed by one of the keys indicated in the signing_keys property.
        /// </summary>
        [JsonProperty("shasums_signature_url", Required = Required.Always)]
        public string ShaSumSignatureUrl { get; set; }

        /// <summary>
        /// A URL from which Terraform can retrieve a text document recording expected SHA256 checksums for this package and possibly other
        /// packages for the same provider version on other platforms.
        /// </summary>
        [JsonProperty("shasums_url", Required = Required.Always)]
        public string ShaSumUrl { get; set; }

        /// <summary>
        /// Get or set the version of this package
        /// </summary>
        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }
    }
}
