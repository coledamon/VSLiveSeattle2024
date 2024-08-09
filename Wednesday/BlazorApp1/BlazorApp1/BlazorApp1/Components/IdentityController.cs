using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorApp1.Components
{
    public class IdentityController : Controller
    {
        [HttpGet]
        public IdentityData Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var result = new IdentityData
            {
                AuthenticationType = identity?.AuthenticationType,
                Claims = identity?.Claims.Select( c => new ClaimsData
                {

                })
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
