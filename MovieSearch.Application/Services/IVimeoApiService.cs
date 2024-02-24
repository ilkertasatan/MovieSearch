using MovieSearch.Domain.ValueObjects;

namespace MovieSearch.Application.Services;

public interface IVimeoApiService
{
    Task<IEnumerable<VideoUri>?> GetMovieVideosByAsync(string movieTitle);
}