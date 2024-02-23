using MovieSearch.Application.Common.Models;

namespace MovieSearch.Application.Common.Interfaces;

public interface IVimeoService
{
    Task<IEnumerable<MovieVideo>> GetMovieVideosByAsync(string movieTitle);
}