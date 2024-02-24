namespace MovieSearch.Infrastructure.Constants;

public static class CacheKeys
{
    public static readonly Func<string, string> MovieByTitle = movieTitle => $"movie-{movieTitle}";
    public static readonly Func<string, string> MovieVideoByTitle = movieTitle => $"movie-video-{movieTitle}";
}