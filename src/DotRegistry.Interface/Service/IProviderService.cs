using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract.Provider;

namespace DotRegistry.Interface.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProviderService : IEntityService<ProviderEntity>
    {
        /// <summary>
        /// Get a Terraform binary package
        /// </summary>
        /// <param name="nSpace">Provider namespace such as company name or GitHub URL</param>
        /// <param name="name">The name of the provider</param>
        /// <param name="packageVersion">The published version of the provider package</param>
        /// <param name="packageOs">The package operating system</param>
        /// <param name="packageArchitecture">The package CPU architecture</param>
        /// <returns></returns>
        Task<ProviderPackageEntity> GetPackageAsync(
            string nSpace,
            string name,
            string packageVersion,
            string packageOs,
            string packageArchitecture
        );

        /// <summary>
        /// Get a Terraform provider
        /// </summary>
        /// <param name="nSpace">Provider namespace such as company name or GitHub URL</param>
        /// <param name="name">The name of the provider</param>
        /// <returns>The provider object matching namespace and name</returns>
        Task<ProviderEntity> GetProviderAsync(string nSpace, string name);

        /// <summary>
        /// Get all published versions of a Terraform provider
        /// </summary>
        /// <param name="nSpace">Provider namespace such as company name or GitHub URL</param>
        /// <param name="name">The name of the provider</param>
        /// <returns>An object containing a list of published versions and their supported platforms</returns>
        Task<ProviderVersionsEntity> GetProviderVersionsAsync(string nSpace, string name);

        /// <summary>
        /// Get all providers published by a given user
        /// </summary>
        /// <param name="publishedBySlug">The slug of the user account</param>
        /// <returns>List of all providers published by given user</returns>
        Task<List<ProviderEntity>> GetProvidersByPublishingUser(string publishedBySlug);

        /// <summary>
        /// Publish a provider from a GitHub repository to the registry
        /// </summary>
        /// <param name="repositoryName">Name of the repository to publish.</param>
        Task PublishProvider(string repositoryName);
    }
}
