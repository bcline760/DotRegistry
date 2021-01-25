using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract.Provider;

namespace DotRegistry.Interface.Repository
{
    public interface IProviderRepository : IRepository<ProviderEntity>
    {
        /// <summary>
        /// Get a Terraform provider
        /// </summary>
        /// <param name="nSpace">Provider namespace such as company name or GitHub URL</param>
        /// <param name="name">The name of the provider</param>
        /// <returns>The provider object matching namespace and name</returns>
        Task<ProviderEntity> GetProviderAsync(string nSpace, string name);

        /// <summary>
        /// Get all providers published by a given user
        /// </summary>
        /// <param name="publishedBySlug">The slug of the user account</param>
        /// <returns>List of all providers published by given user</returns>
        Task<List<ProviderEntity>> GetProvidersByPublishingUser(string publishedBySlug);
    }
}
