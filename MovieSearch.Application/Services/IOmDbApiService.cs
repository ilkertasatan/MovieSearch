using MovieSearch.Domain.Movies;

namespace MovieSearch.Application.Services;

public interface IOmDbApiService
{
    Task<Movie?> GetMovieInfoByAsync(string movieTitle);
}