using System;


using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using DotRegistry.Core.Logging;

namespace DotRegistry.Web.Controllers
{
    public class AuthController : Controller
    {
        public AuthController(ILog log)
        {

        }

        public IActionResult Index(string returnUrl="/")
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
