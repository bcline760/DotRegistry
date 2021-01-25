using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Octokit;
using Octokit.Internal;
using DotRegistry.Interface.Service;

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

        [HttpGet, Route("authenticated/{user}")]
        public async Task<IActionResult> GetAuthenticatedUser(string user)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            Service.AccessToken = accessToken;
            var githubUser = await Service.GetAuthenticatedUser(user);

            return Ok(githubUser);
        }

        public IGitHubService Service { get; protected set; }
    }
}
