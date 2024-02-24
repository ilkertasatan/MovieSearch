namespace MovieSearch.Infrastructure.Constants;

public static class CacheKeys
{
    public static Func<string, string> MovieByTitle = movieTitle => $"movie-{movieTitle}";
}