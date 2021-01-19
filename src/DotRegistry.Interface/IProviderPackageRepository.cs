using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract;

namespace DotRegistry.Interface
{
    public interface IProviderPackageRepository : IRepository<ProviderPackage>
    {
        /// <summary>
        /// Get available packages by namespace and type
        /// </summary>
        /// <param name="ns">The package namespace</param>
        /// <param name="type">The package type or name</param>
        /// <returns>List of packages matching namespace and type</returns>
        Task<List<ProviderPackage>> GetPackagesAsync(string ns, string type);

        /// <summary>
        /// Get all available provider packages by a version number
        /// </summary>
        /// <param name="ns">The namespace of the package</param>
        /// <param name="type">Tye type of package, usually this is the actual name of the provider package</param>
        /// <param name="version">The version number in MAJOR.MINOR.BUILD</param>
        /// <returns></returns>
        Task<List<ProviderPackage>> GetPackagesByVersionAsync(string ns, string type, string version);
    }
}
