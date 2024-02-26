using MovieSearch.Domain.ValueObjects;

namespace MovieSearch.Application.Services;

public interface IVimeoApiService
{
    Task<IList<VideoUri>?> GetMovieVideosByAsync(string movieTitle);
}