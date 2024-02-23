using MovieSearch.Domain.ValueObjects;

namespace MovieSearch.Application.Common.Interfaces;

public interface IVimeoApiService
{
    Task<IEnumerable<VideoUri>> GetMovieVideosByAsync(string movieTitle);
}