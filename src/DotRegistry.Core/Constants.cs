using System;
namespace DotRegistry.Core
{
    /// <summary>
    /// Defines a series of constants used throughout the application
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ConnectionStringEnvName = "DB_CONNECT_STR";

        /// <summary>
        /// Environment variable for the GitHub client ID
        /// </summary>
        public static readonly string GitHubClientIdEnvName = "GITHUB_CLIENT_ID";

        /// <summary>
        /// Environment variable for the GitHub client secret
        /// </summary>
        public static readonly string GitHubClientSecretEnvName = "GITHUB_CLIENT_SECRET";

        /// <summary>
        /// Get the default GitHub API URL
        /// </summary>
        public static readonly string GitHubApiDefaultUrl = "https://api.github.com";

        /// <summary>
        /// The property used to retrieve the environment variable for the GitHub API URL
        /// </summary>
        public static readonly string GitHubApiUrlEnvName = "GITHUB_API_URL";
    }
}
