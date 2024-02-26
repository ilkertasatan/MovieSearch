using MovieSearch.Application.Abstractions.Caching;
using MovieSearch.Application.Services;
using MovieSearch.Domain.Movies;
using MovieSearch.Infrastructure.Constants;

namespace MovieSearch.Infrastructure.Services.OmDb;

public sealed class CachingOmDbApiService(
    IOmDbApiService omDbApiService,
    ICacheProvider cacheProvider) : IOmDbApiService
{
    private static readonly TimeSpan CacheTime = TimeSpan.FromHours(12);
    
    public async Task<Movie?> GetMovieInfoByAsync(string movieTitle)
    {
        var movie = cacheProvider.GetItem<Movie>(CacheKeys.MovieByTitle(movieTitle));
        if (movie is not null) 
            return movie;
        
        movie = await omDbApiService.GetMovieInfoByAsync(movieTitle);
        cacheProvider.SetItem(CacheKeys.MovieByTitle(movieTitle), movie, CacheTime);

        return movie;
    }
}