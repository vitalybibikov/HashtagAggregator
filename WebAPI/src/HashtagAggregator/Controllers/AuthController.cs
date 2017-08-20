using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HashtagAggregator.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> logger;

        public AuthController(ILogger<AuthController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            logger.LogInformation("Information from IActionResult");
            return new JsonResult("desu");
        }
    }
}