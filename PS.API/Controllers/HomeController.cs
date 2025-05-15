using Microsoft.AspNetCore.Mvc;

namespace PS.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("API PetScan funcionando correctamente.");
        }
    }
}
