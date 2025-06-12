using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Starwars.App.Api.Controllers
{
    public class DemoController : Controller
    {

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Route("api/demo/demo1")]
        [HttpGet]
        public IActionResult Demo1()
        {
            return Ok("This is a demo 1 response from DemoController.");
        }


        [Route("api/demo/demo2")]
        [HttpGet]
        [Authorize]
        public IActionResult Demo2()
        {
            return Ok("This is a demo 2 response from DemoController.");
        }
    }
}
