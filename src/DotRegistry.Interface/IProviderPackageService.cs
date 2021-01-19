using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract;

namespace DotRegistry.Interface
{
    public interface IProviderPackageService : IEntityService<ProviderPackage>
    {
        /// <summary>
        /// Get available packages by namespace and type
        /// </summary>
        /// <param name="ns">The package namespace</param>
        /// <param name="type">The package type or name</param>
        /// <returns>List of packages matching namespace and type</returns>
        Task<List<ProviderPackage>> GetPackagesAsync(string ns, string type);
    }
}
