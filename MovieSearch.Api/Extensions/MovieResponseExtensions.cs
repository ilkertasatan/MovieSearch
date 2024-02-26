using MovieSearch.Api.Models;
using MovieSearch.Domain.Movies;

namespace MovieSearch.Api.Extensions;

public static class MovieResponseExtensions
{
    public static MovieResponse ToResponse(this Movie movie)
    {
        return new MovieResponse(
            movie.MovieId.ToString(),
            movie.Title.ToString(),
            movie.Year.ToString(),
            movie.Genres.Select(genre => genre.ToString()).ToList(),
            movie.Directors.Select(director => director.ToString()).ToList(),
            movie.Writers.Select(writer => writer.ToString()).ToList(),
            movie.Actors.Select(actor => actor.ToString()).ToList(),
            movie.Plot.ToString(),
            movie.Languages.Select(language => language.ToString()).ToList(),
            movie.VideoUris.Select(uri => uri.ToString()).ToList());
    }
}