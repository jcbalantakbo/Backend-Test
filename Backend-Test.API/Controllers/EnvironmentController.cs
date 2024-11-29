using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend_Test.Controllers
{
    [Route("api/environment")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        [HttpGet("isproduction")]
        public ActionResult<bool> IsProduction()
        {
            // If the debugger is attached, it's likely not a production environment.
            bool isProduction = !Debugger.IsAttached;
            return Ok(isProduction);
        }

        [HttpGet("apiversion")]
        public ActionResult<string> GetApiVersion()
        {
            const string apiVersion = "2.4"; // Update this version when modifying core functionality.
            return Ok($"API Version is {apiVersion}");
        }

        [HttpGet("uiversion")]
        public ActionResult<string> GetUIVersion()
        {
            const string uiVersion = "4.8"; // Update this version when modifying the UI.
            return Ok($"UI Version is {uiVersion}");
        }
    }
}
