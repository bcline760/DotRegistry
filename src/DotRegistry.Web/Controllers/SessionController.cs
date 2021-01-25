using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DotRegistry.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        [HttpGet, Route("login")]
        public IActionResult Login(string returnUrl="/")
        {
            return Challenge(new AuthenticationProperties()
            {
                RedirectUri = returnUrl
            });
        }
    }
}
