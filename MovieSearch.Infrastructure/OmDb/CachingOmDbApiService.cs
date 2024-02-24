using Microsoft.Extensions.Caching.Memory;
using MovieSearch.Application.Services;
using MovieSearch.Domain.Movies;
using MovieSearch.Infrastructure.Constants;

namespace MovieSearch.Infrastructure.OmDb;

public sealed class CachingOmDbApiService(
    IOmDbApiService omDbApiService,
    IMemoryCache memoryCache) : IOmDbApiService
{
    private static readonly TimeSpan CacheTime = TimeSpan.FromHours(12);
    
    public Task<Movie?> GetMovieInfoByAsync(string movieTitle)
    {
        return memoryCache.GetOrCreateAsync(
            CacheKeys.MovieByTitle(movieTitle),
            cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(CacheTime);
                return omDbApiService.GetMovieInfoByAsync(movieTitle);
            });
    }
}