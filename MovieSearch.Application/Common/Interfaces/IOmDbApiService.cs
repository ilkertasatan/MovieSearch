using MovieSearch.Application.Common.Models;

namespace MovieSearch.Application.Common.Interfaces;

public interface IOmDbApiService
{
    Task<MovieInfo> GetMovieInfoByAsync(string movieTitle);
}