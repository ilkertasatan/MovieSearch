namespace MovieSearch.Application.Abstractions.Caching;

public interface ICacheProvider
{
    TItem? GetItem<TItem>(string cacheKey);
    TItem SetItem<TItem>(string cacheKey, TItem value, TimeSpan absoluteExpirationRelativeToNow);
}