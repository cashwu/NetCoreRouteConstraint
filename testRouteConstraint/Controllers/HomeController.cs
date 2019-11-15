using Microsoft.AspNetCore.Mvc;

namespace testRouteConstraint.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("OK");
        }
        
        [HttpGet]
        [Route("~/api/{email:email}")]
        public IActionResult Email(string email)
        {
            return Content($"Coming from mail {email}");
        }
    }
}