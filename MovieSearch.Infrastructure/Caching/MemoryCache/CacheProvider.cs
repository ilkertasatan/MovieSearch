using Microsoft.Extensions.Caching.Memory;
using MovieSearch.Application.Abstractions.Caching;

namespace MovieSearch.Infrastructure.Caching.MemoryCache;

public sealed class CacheProvider(IMemoryCache memoryCache) : ICacheProvider
{
    public TItem? GetItem<TItem>(string cacheKey)
    {
        return memoryCache.Get<TItem>(cacheKey);
    }

    public TItem SetItem<TItem>(string cacheKey, TItem value, TimeSpan absoluteExpirationRelativeToNow)
    {
        return memoryCache.Set(cacheKey, value, absoluteExpirationRelativeToNow);
    }
}