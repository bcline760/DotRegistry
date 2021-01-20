using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract;
namespace DotRegistry.Interface
{
    public interface IGitHubService : IEntityService<GitHubUser>
    {
        List<Task<string>> GetRepositories(string username);

        Task GetReleasesAsync(string username, string repoName);
    }
}
