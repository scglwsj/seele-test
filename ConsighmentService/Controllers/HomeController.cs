using Microsoft.AspNetCore.Mvc;

namespace ConsighmentService.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string HelthCheck(string name = "world")
        {
            return $"Hello, {name}!";
        }
    }
}
