using MovieSearch.Domain.Movies;

namespace MovieSearch.Application.UseCases.MovieSearch;

public sealed class MovieSearchQuerySuccessResult(Movie movie) : IQueryResult
{
    public Movie Movie { get; } = movie;
}