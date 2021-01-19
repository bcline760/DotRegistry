using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DotRegistry.Contract;
using DotRegistry.Interface;

namespace DotRegistry.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        public ProviderController(IProviderPackageService prService)
        {
            ProviderService = prService;
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

        [HttpGet("{ns}/{type}/versions", Name = "GetVersionsAsync")]
        public async Task<IActionResult> Get(string ns, string type)
        {
            try
            {
                var packages = await ProviderService.GetPackagesAsync(ns, type);

                if (packages.Count > 0)
                {
                    return new OkObjectResult(packages);
                }
            }
            catch (Exception ex)
            {

            }
        }

        [HttpGet("{ns}/{type}/{version}/download/{opSys}/{arch}", Name = "GetPackageAsync")]
        public async Task<IActionResult> Get(string ns, string type, string version, string opSys, string arch)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        // POST: api/Provider
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IActionResult value)
        {
        }

        // PUT: api/Provider/5
        [HttpPut("{slug}")]
        public async Task<IActionResult> Put(string slug, [FromBody] IActionResult value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{slug}")]
        public async Task<IActionResult> Delete(string slug)
        {
        }

        protected IProviderPackageService ProviderService { get; }
    }
}
