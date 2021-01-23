using MongoDB.Bson.Serialization.Attributes;

namespace DotRegistry.Model.Provider
{
    public class ProviderPackageModel
    {
        /// <summary>
        /// This must currently echo back the arch parameter from the request. Other possibilities may come in later versions of this protocol.
        /// </summary>
        [BsonElement("arch"), BsonRequired]
        public string Architecture { get; set; }

        /// <summary>
        /// A URL from which Terraform can retrieve the provider's zip archive.
        /// If this is a relative URL then it will be resolved relative to the URL that returned the containing JSON object.
        /// </summary>
        [BsonElement("download_url"), BsonRequired]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// The filename for this provider's zip archive as recorded in the "shasums" document,
        /// so that Terraform CLI can determine which of the given checksums should be used for this specific package.
        /// </summary>
        [BsonElement("filename"), BsonRequired]
        public string Filename { get; set; }

        /// <summary>
        /// This must currently echo back the os parameter from the request.
        /// Other possibilities may come in later versions of this protocol.
        /// </summary>
        [BsonElement("os"), BsonRequired]
        public string OperatingSystem { get; set; }

        /// <summary>
        /// An object describing signing keys for this provider package, one of which must have been used to produce the signature at shasums_signature_url.
        /// </summary>
        [BsonElement("signing_keys"), BsonRequired]
        public SigningKeyModel SigningKey { get; set; }

        /// <summary>
        /// The SHA256 Hash of the provider binary
        /// </summary>
        [BsonElement("shasum"), BsonRequired]
        public string ShaSum { get; set; }

        /// <summary>
        /// A URL from which Terraform can retrieve a binary, detached GPG signature for the document at shasums_url,
        /// signed by one of the keys indicated in the signing_keys property.
        /// </summary>
        [BsonElement("shasums_signature_url"), BsonRequired]
        public string ShaSumSignatureUrl { get; set; }

        /// <summary>
        /// A URL from which Terraform can retrieve a text document recording expected SHA256 checksums for this package and possibly other
        /// packages for the same provider version on other platforms.
        /// </summary>
        [BsonElement("shasums_url"), BsonRequired]
        public string ShaSumUrl { get; set; }

        /// <summary>
        /// Get or set the version of this package
        /// </summary>
        [BsonElement("version"), BsonRequired]
        public string Version { get; set; }
    }
}
