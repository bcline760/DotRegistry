﻿using System;
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

        public static readonly string GitHubApiUrl = "https://api.github.com";

        /// <summary>
        /// The property used to retrieve the environment variable for the GitHub API URL
        /// </summary>
        public static readonly string GitHubApiUrlEnvName = "GITHUB_API_URL";
    }
}
