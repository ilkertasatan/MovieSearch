using MovieSearch.Application.Abstractions.Caching;
using MovieSearch.Application.Services;
using MovieSearch.Domain.ValueObjects;
using MovieSearch.Infrastructure.Constants;

namespace MovieSearch.Infrastructure.Services.Vimeo;

public sealed class CachingVimeoApiService(
    IVimeoApiService vimeoApiService,
    ICacheProvider cacheProvider) : IVimeoApiService
{
    private static readonly TimeSpan CacheTime = TimeSpan.FromHours(12);
    
    public async Task<IList<VideoUri>?> GetMovieVideosByAsync(string movieTitle)
    {
        var videoUris = cacheProvider.GetItem<IList<VideoUri>?>(CacheKeys.MovieVideoByTitle(movieTitle));
        if (videoUris is not null)
            return videoUris;

        videoUris = await vimeoApiService.GetMovieVideosByAsync(movieTitle);
        cacheProvider.SetItem(CacheKeys.MovieVideoByTitle(movieTitle), videoUris, CacheTime);

        return videoUris;
    }
}