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
        /// Get a user's profile from the data store or GitHub
        /// </summary>
        /// <param name="username"></param>
        /// <returns>The profile matching the user</returns>
        Task<UserProfileEntity> GetAuthenticatedUser(string username);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<List<GitHubRepository>> GetRepositories(string username);
    }
}
