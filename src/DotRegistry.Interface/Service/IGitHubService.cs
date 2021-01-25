using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract;
using DotRegistry.Contract.GitHub;

namespace DotRegistry.Interface.Service
{
    public interface IGitHubService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<UserProfile> GetAuthenticatedUser(string username);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<List<GitHubRepository>> GetRepositories(string username);

        /// <summary>
        /// Set this parameter before making GitHub API calls.
        /// </summary>
        string AccessToken { get; set; }
    }
}
