﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotRegistry.Contract;
using DotRegistry.Contract.GitHub;
using DotRegistry.Interface.Repository;
using DotRegistry.Interface.Service;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

using Octokit;
using Octokit.Internal;

namespace DotRegistry.Service
{
    public class GitHubService : IGitHubService
    {
        public GitHubService(IGitHubApiRepository githubApi, IUserProfileRepository userRepository, IHttpContextAccessor accessor)
        {
            Accessor = accessor;
            GitHubRepo = githubApi;
            UserRepository = userRepository;
        }

        public async Task<UserProfileEntity> GetAuthenticatedUser(string username)
        {
            string token = await Accessor.HttpContext.GetTokenAsync("access_token");
            var gitHubClient = new GitHubClient(new ProductHeaderValue(username), new InMemoryCredentialStore(new Credentials(token)));
            var gitHubUser = await gitHubClient.User.Current();

            var profile = await UserRepository.GetByLogin(username);

            // If no profile exists, create one and store it to the DB
            if (profile == null)
            {
                var gitHubKeys = await gitHubClient.User.GpgKey.GetAllForCurrent();
                var newProfile = new UserProfileEntity
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

                    await UserRepository.SaveAsync(profile);
                }
            }

            return profile;
        }

        public async Task<List<GitHubRepository>> GetRepositories(string username)
        {
            string token = await Accessor.HttpContext.GetTokenAsync("access_token");
            var repositories = await GitHubRepo.GetRepositories(username, username, token);
            repositories = repositories
                .Where(r => !r.Private && r.FullName.StartsWith("terraform-provider-"))
                .ToList();

            return repositories;
        }

        protected IGitHubApiRepository GitHubRepo { get; private set; }

        protected IHttpContextAccessor Accessor { get; private set; }

        protected IUserProfileRepository UserRepository { get; private set; }
    }
}