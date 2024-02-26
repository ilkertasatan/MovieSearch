using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieSearch.Api.Extensions;
using MovieSearch.Application.UseCases.SearchMovie;

namespace MovieSearch.Api.Controllers;

/// <summary>
/// Movie Search Api
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
public class MoviesController(ISender mediator) : ApiController
{
    /// <summary>
    /// Returns movie detail given by title
    /// </summary>
    /// <param name="title">Movie Title</param>
    /// <returns></returns>
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SearchMovieAsync([FromQuery] [Required] string title)
    {
        var result = await mediator.Send(new SearchMovieQuery(title));

        return result.Match(
            movie => Ok(movie.ToResponse()),
            Problem);
    }
}