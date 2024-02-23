using Microsoft.AspNetCore.Mvc;

namespace MovieSearch.Api.Controllers;

/// <summary>
/// Movie Search Api
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class MovieSearchController : ControllerBase
{
    /// <summary>
    /// Search movie from external sources by movie title
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult MovieSearchAsync([FromQuery] string title)
    {
        return Ok();
    }
}