using System.Threading.Tasks;

using DotRegistry.Contract;
namespace DotRegistry.Interface
{
    /// <summary>
    /// Provides access to GitHub user entries in the database.
    /// </summary>
    public interface IGitHubUserRepository : IRepository<GitHubUser>
    {
        /// <summary>
        /// Get a GitHub user by their username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A GitHub user </returns>
        Task<GitHubUser> GetByUsernameAsync(string username);
    }
}
