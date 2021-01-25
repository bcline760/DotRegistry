using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using log4net;

using DotRegistry.Contract;
using DotRegistry.Interface.Service;
using DotRegistry.Core.Logging;

namespace DotRegistry.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        public ProviderController(IProviderService prService, ILog log)
        {
            ProviderService = prService;
            Log = log;
        }

        // GET: api/Provider
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var providers = await ProviderService.GetAllAsync();

            return new OkObjectResult(providers);
        }

        // GET: api/Provider/5
        [HttpGet("{slug}", Name = "Get")]
        public async Task<IActionResult> Get(string slug)
        {
            var provider = await ProviderService.GetAsync(slug);

            if (provider == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(provider);
        }

        [HttpGet("{ns}/{name}/versions", Name = "GetVersionsAsync")]
        public async Task<IActionResult> Get(string ns, string name)
        {
            try
            {
                var versions = await ProviderService.GetProviderVersionsAsync(ns, name);

                if (versions != null)
                {
                    return new OkObjectResult(versions);
                }

                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                ex.IfNotLoggedThenLog(Log);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{ns}/{name}/{version}/download/{opSys}/{arch}", Name = "GetPackageAsync")]
        public async Task<IActionResult> Get(string ns, string name, string version, string opSys, string arch)
        {
            try
            {
                var package = await ProviderService.GetPackageAsync(ns, name, version, opSys, arch);
                if (package == null)
                    return new NotFoundResult();

                return new OkObjectResult(package);
            }
            catch (Exception ex)
            {
                ex.IfNotLoggedThenLog(Log);
                return new StatusCodeResult(500);
            }
        }

        protected IProviderService ProviderService { get; }

        protected ILog Log { get; }
    }
}
