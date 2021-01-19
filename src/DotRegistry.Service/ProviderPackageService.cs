using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract;
using DotRegistry.Interface;

namespace DotRegistry.Service
{
    public class ProviderPackageService : EntityService<ProviderPackage>, IProviderPackageService
    {
        public ProviderPackageService(IProviderPackageRepository repo) : base(repo)
        {
        }

        public async Task<List<ProviderPackage>> GetPackagesAsync(string ns, string type)
        {
            var repo = Repository as IProviderPackageRepository;

            return await repo.GetPackagesAsync(ns, type);
        }
    }
}
