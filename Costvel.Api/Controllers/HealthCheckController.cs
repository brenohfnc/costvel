using Microsoft.AspNetCore.Mvc;

namespace Costvel.Api.Controllers;

[ApiController]
[Route("health-check")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Alive");
    }
}