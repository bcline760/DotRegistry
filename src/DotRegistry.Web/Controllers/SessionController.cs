using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using log4net;


using DotRegistry.Core.Logging;

namespace DotRegistry.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public SessionController(ILog log)
        {
            Log = log;
        }

        [HttpGet, Route("login")]
        public IActionResult Login(string returnUrl="/")
        {
            try
            {
                return Challenge(new AuthenticationProperties()
                {
                    RedirectUri = returnUrl
                });
            }
            catch (Exception e)
            {
                e.IfNotLoggedThenLog(Log);
                return StatusCode(500);
            }
        }

        public ILog Log { get; protected set; }
    }
}
