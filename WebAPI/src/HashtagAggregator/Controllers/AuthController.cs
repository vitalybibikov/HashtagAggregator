using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HashtagAggregator.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return new JsonResult("desu");
        }
    }
}
