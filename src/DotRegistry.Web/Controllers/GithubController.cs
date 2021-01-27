using System.Linq;
using System.Threading.Tasks;

using DotRegistry.Interface.Service;

using Microsoft.AspNetCore.Mvc;

namespace DotRegistry.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        public GithubController(IGitHubService service)
        {
            Service = service;
        }

        [HttpGet, Route("check")]
        public IActionResult IsAuthenticated()
        {
            if (User.Identity.IsAuthenticated)
                return Ok();

            return Unauthorized();
        }

        [HttpGet, Route("user")]
        public async Task<IActionResult> GetAuthenticatedUser()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var user = User.Claims.First(c => c.Type == "urn:github:login");

            var githubUser = await Service.GetAuthenticatedUser(user.Value);

            return Ok(githubUser);
        }

        public IGitHubService Service { get; protected set; }
    }
}