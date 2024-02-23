using System.ComponentModel.DataAnnotations;
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
    /// Returns movie detail given by title
    /// </summary>
    /// <param name="title">Movie Title</param>
    /// <returns></returns>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult MovieSearchAsync([FromQuery] [Required] string title)
    {
        return Ok();
    }
}