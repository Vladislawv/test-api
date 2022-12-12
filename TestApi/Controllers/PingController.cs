using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/ping")]
public class PingController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    /// <summary>
    /// Ping controller with empty response body
    /// </summary>
    /// <returns></returns>
    public Task<IActionResult> PingAsync()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}