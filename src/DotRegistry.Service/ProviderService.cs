using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotRegistry.Contract.Provider;
using DotRegistry.Interface.Repository;
using DotRegistry.Interface.Service;
using log4net;

namespace DotRegistry.Service
{
    public class ProviderService : EntityService<ProviderEntity>, IProviderService
    {
        public ProviderService(IProviderRepository repository, IGitHubService gitHubService, ILog log) : base(repository, log)
        {
        }

        public async Task<ProviderPackageEntity> GetPackageAsync(string nSpace, string name, string packageVersion, string packageOs, string packageArchitecture)
        {
            var iface = this.Repository as IProviderRepository;

            var provider = await iface.GetProviderAsync(nSpace, name);

            if (provider !=null)
            {
                var package = provider.Packages
                    .Where(p => p.Architecture == packageArchitecture && p.OperatingSystem == packageOs && p.Version == packageVersion)
                    .FirstOrDefault();

                return package;
            }

            return null;
        }

        public async Task<ProviderEntity> GetProviderAsync(string nSpace, string name)
        {
            return await ((IProviderRepository)this.Repository).GetProviderAsync(nSpace, name);
        }

        public async Task<List<ProviderEntity>> GetProvidersByPublishingUser(string publishedBySlug)
        {
            var iface = this.Repository as IProviderRepository;

            return await iface.GetProvidersByPublishingUser(publishedBySlug);
        }

        public async Task<ProviderVersionsEntity> GetProviderVersionsAsync(string nSpace, string name)
        {
            var iface = this.Repository as IProviderRepository;

            var provider = await iface.GetProviderAsync(nSpace, name);

            if (provider != null)
            {
                var packageGroup = provider.Packages
                    .GroupBy(
                        p => p.Version,
                        p => p,
                        (version, package) => new
                        {
                            Version = version,
                            Package = package
                        })
                    .Select(p => new ProviderVersionEntity
                    {
                        Version = p.Version,
                        Protocols = new List<string> { "4.1", "5" },
                        Platforms = p.Package.Select(s => new ProviderPlatformEntity
                        {
                            Architecture = s.Architecture,
                            OperatingSystem = s.OperatingSystem
                        }).ToList()
                    });

                return new ProviderVersionsEntity
                {
                    Versions = packageGroup.ToList()
                };
            }

            return null;
        }

        public async Task PublishProvider(string repositoryName)
        {
            throw new NotImplementedException();
        }
    }
}
