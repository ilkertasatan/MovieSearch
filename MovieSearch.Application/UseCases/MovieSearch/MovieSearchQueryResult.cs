using MovieSearch.Domain.Movies;

namespace MovieSearch.Application.UseCases.MovieSearch;

public sealed class MovieSearchQueryResult(Movie movie)
{
    public Movie Movie { get; } = movie;
}