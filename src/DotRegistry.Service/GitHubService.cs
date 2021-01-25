using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotRegistry.Contract;
using DotRegistry.Contract.GitHub;
using DotRegistry.Interface.Repository;
using DotRegistry.Interface.Service;
using Octokit;
using Octokit.Internal;

namespace DotRegistry.Service
{
    public class GitHubService : IGitHubService
    {
        public GitHubService(IGitHubApiRepository githubApi, IUserProfileRepository userRepository)
        {
            GitHubRepository = githubApi;
            UserRepository = userRepository;
        }

        public string AccessToken { get; set; }

        public async Task<UserProfile> GetAuthenticatedUser(string username)
        {
            if (string.IsNullOrEmpty(AccessToken))
                throw new InvalidOperationException("Missing access token");

            var gitHubClient = new GitHubClient(new ProductHeaderValue(username), new InMemoryCredentialStore(new Credentials(AccessToken)));
            var gitHubUser = await gitHubClient.User.Current();

            var profile = await UserRepository.GetByLogin(username);

            // If no profile exists, create one and store it to the DB
            if (profile == null)
            {
                var gitHubKeys = await gitHubClient.User.GpgKey.GetAllForCurrent();
                var newProfile = new UserProfile
                {
                    Active = true,
                    CreatedAt = DateTime.UtcNow,
                    AvatarUrl = gitHubUser.AvatarUrl,
                    Bio = gitHubUser.Bio,
                    Email = gitHubUser.Email,
                    HtmlUrl = gitHubUser.HtmlUrl,
                    Location = gitHubUser.Location,
                    Login = gitHubUser.Login,
                    Name = gitHubUser.Name,
                    NodeId = gitHubUser.NodeId,
                    Url = gitHubUser.Url,
                    SigningKeys = gitHubKeys.Where(w => w.CanSign).Select(s => new GitHubGpgKey
                    {
                        DateAdded = s.CreatedAt.UtcDateTime,
                        GpgPublicKey = s.PublicKey,
                        KeyId = s.KeyId,
                        Namespace = username
                    }).ToList()
                };
                profile = newProfile;
                await UserRepository.SaveAsync(newProfile);
            }
            else
            {
                // If they updated their GitHub profile recently, update the DB
                if (gitHubUser.UpdatedAt.UtcDateTime > gitHubUser.UpdatedAt)
                {
                    var gitHubKeys = await gitHubClient.User.GpgKey.GetAllForCurrent();
                    profile.AvatarUrl = gitHubUser.AvatarUrl;
                    profile.Bio = gitHubUser.Bio;
                    profile.Email = gitHubUser.Email;
                    profile.HtmlUrl = gitHubUser.HtmlUrl;
                    profile.Location = gitHubUser.Location;
                    profile.Login = gitHubUser.Login;
                    profile.Name = gitHubUser.Name;
                    profile.Url = gitHubUser.Url;
                    profile.SigningKeys = gitHubKeys.Where(w => w.CanSign).Select(s => new GitHubGpgKey
                    {
                        DateAdded = s.CreatedAt.UtcDateTime,
                        GpgPublicKey = s.PublicKey,
                        KeyId = s.KeyId,
                        Namespace = username
                    }).ToList();
                }
            }

            return profile;
        }

        public async Task<List<GitHubRepository>> GetRepositories(string username)
        {
            var gitHubClient = new GitHubClient(new ProductHeaderValue(username), new InMemoryCredentialStore(new Credentials(AccessToken)));
            var gitHubRepos = await gitHubClient.Repository.GetAllForCurrent();

            var rawTerraformRepos = gitHubRepos.Where(r => !r.Archived && !r.Private && r.Name.StartsWith("terraform-provider-"));

            var terraformRepositories = rawTerraformRepos.Select(r => new GitHubRepository
            {
                AllowMergeCommit = r.AllowMergeCommit.HasValue ? r.AllowMergeCommit.Value : false,
                AllowRebaseMerge = r.AllowRebaseMerge.HasValue ? r.AllowRebaseMerge.Value : false,
                AllowSquashMerge = r.AllowSquashMerge.HasValue ? r.AllowSquashMerge.Value : false,
                Archived = false,
                ArchiveUrl = null,
                CloneUrl = new Uri(r.CloneUrl),
                CreatedAt = r.CreatedAt.UtcDateTime,
                FullName = r.FullName,
                Fork = r.Fork,
                OpenIssuesCount = r.OpenIssuesCount,
                Owner = new GitHubOwner
                {
                    AvatarUrl = new Uri(r.Owner.AvatarUrl),
                    Id = r.Owner.Id,
                    Login = r.Owner.Login,
                    Type = r.Owner.Type.HasValue ? r.Owner.Type.Value.ToString() : AccountType.User.ToString()
                },
                Private = false,
                Size = r.Size,
                SvnUrl = new Uri(r.SvnUrl),
                Url = new Uri(r.Url)
            }).ToList();

            return terraformRepositories;
        }

        protected IGitHubApiRepository GitHubRepository { get; private set; }

        protected IUserProfileRepository UserRepository { get; private set; }
    }
}
