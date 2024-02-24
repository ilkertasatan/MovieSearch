using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieSearch.Api.Models;
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
            movie =>
                new OkObjectResult(
                    new MovieResponse(
                        movie.MovieId.ToString(),
                        movie.Title.ToString(),
                        movie.Year.ToString(),
                        movie.Genres.Select(genre => genre.ToString()).ToList(),
                        movie.Directors.Select(director => director.ToString()).ToList(),
                        movie.Writers.Select(writer => writer.ToString()).ToList(),
                        movie.Actors.Select(actor => actor.ToString()).ToList(),
                        movie.Plot.ToString(),
                        movie.Languages.Select(language => language.ToString()).ToList(),
                        movie.VideoUris.Select(uri => uri.ToString()).ToList())),
            Problem);
    }
}