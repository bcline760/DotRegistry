using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using log4net;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

using DotRegistry.Contract.GitHub;
using DotRegistry.Core.Logging;
using DotRegistry.Core;
using DotRegistry.Interface.Repository;

namespace DotRegistry.Model.GitHub
{
    public class GitHubApiRepository : IGitHubApiRepository
    {
        public GitHubApiRepository(ILog log)
        {
            string gitHubApiUrl = Environment.GetEnvironmentVariable(Constants.GitHubApiUrlEnvName);

            // If the GitHub API URL isn't defined, default to the public one.
            GitHubApiUrl = string.IsNullOrEmpty(gitHubApiUrl) ? Constants.GitHubApiDefaultUrl : gitHubApiUrl;

            Log = log;
        }

        public async Task<List<GitHubRepository>> GetRepositories(string nspace, string username, string token)
        {
            string url = $"{GitHubApiUrl}/users/{nspace}/repos";

            return await GetAsync<List<GitHubRepository>>(url, username, token);
        }

        public async Task<GitHubRepository> GetRepository(string nspace, string repoName, string username, string token)
        {
            string url = $"{GitHubApiUrl}/repos/{nspace}/{repoName}";

            return await GetAsync<GitHubRepository>(url, username, token);
        }

        public async Task<GitHubRelease> GetRepositoryReleases(string nspace, string repoName, string username, string token)
        {
            string url = $"{GitHubApiUrl}/repos/{nspace}/{repoName}/releases";
            return await GetAsync<GitHubRelease>(url, username, token);
        }


        private async Task<T> GetAsync<T>(string url, string username, string token)
            where T : class
        {
            T obj = null;
            try
            {
                var client = new RestClient(url);
                client.Timeout = -1;
                client.Authenticator = new HttpBasicAuthenticator(username, token);
                client.AddDefaultHeader("Accept", "application/vnd.github.v3+json");
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var content = response.Content;
                    obj = JsonConvert.DeserializeObject<T>(content);
                }

                if (response.ErrorException != null)
                    throw response.ErrorException.IfNotLoggedThenLog(Log);
            }
            catch (WebException wex)
            {
                throw wex.IfNotLoggedThenLog(Log);
            }

            return obj;
        }
        protected string GitHubApiUrl { get; }

        protected ILog Log { get; }
    }
}
