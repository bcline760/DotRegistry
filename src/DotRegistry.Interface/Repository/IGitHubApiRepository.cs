using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract.GitHub;

namespace DotRegistry.Interface.Repository
{
    public interface IGitHubApiRepository
    {
        /// <summary>
        /// Get all of the repositories belonging to the given namespace.
        /// </summary>
        /// <param name="nspace">The GitHub namespace. Usually this is the username.</param>
        /// <param name="username">The authenticated user</param>
        /// <param name="token">The OAuth token from the interface. This can also be a GitHub PAT</param>
        /// <returns></returns>
        Task<List<GitHubRepository>> GetRepositories(string nspace, string username, string token);

        /// <summary>
        /// Get a particular GitHub repository
        /// </summary>
        /// <param name="nspace">The GitHub namespace. Usually this is the username.</param>
        /// <param name="repoName">The name of the repository</param>
        /// <param name="username">The authenticated user</param>
        /// <param name="token">The OAuth token from the interface. This can also be a GitHub PAT</param>
        /// <returns></returns>
        Task<GitHubRepository> GetRepository(string nspace, string repoName, string username, string token);

        /// <summary>
        /// Get all available releases from a repository
        /// </summary>
        /// <param name="nspace">The GitHub namespace. Usually this is the username.</param>
        /// <param name="repoName">The name of the repository containing releases</param>
        /// <param name="username">The authenticated user</param>
        /// <param name="token">The OAuth token from the interface. This can also be a GitHub PAT</param>
        /// <returns></returns>
        Task<GitHubRelease> GetRepositoryReleases(string nspace, string repoName, string username, string token);

    }
}
