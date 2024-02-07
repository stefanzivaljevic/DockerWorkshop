using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvironmentController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetCurrentEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;
        }
    }
}
