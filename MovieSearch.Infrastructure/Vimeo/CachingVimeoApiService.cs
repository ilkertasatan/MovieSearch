using Microsoft.Extensions.Caching.Memory;
using MovieSearch.Application.Services;
using MovieSearch.Domain.ValueObjects;
using MovieSearch.Infrastructure.Constants;

namespace MovieSearch.Infrastructure.Vimeo;

public sealed class CachingVimeoApiService(
    IVimeoApiService vimeoApiService,
    IMemoryCache memoryCache) : IVimeoApiService
{
    private static readonly TimeSpan CacheTime = TimeSpan.FromHours(12);
    
    public Task<IEnumerable<VideoUri>?> GetMovieVideosByAsync(string movieTitle)
    {
        return memoryCache.GetOrCreateAsync(
            CacheKeys.MovieVideoByTitle(movieTitle),
            cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(CacheTime);
                return vimeoApiService.GetMovieVideosByAsync(movieTitle);
            });
    }
}