using MovieSearch.Domain.Movies;

namespace MovieSearch.Application.Common.Interfaces;

public interface IOmDbApiService
{
    Task<Movie> GetMovieInfoByAsync(string movieTitle);
}