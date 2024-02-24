namespace MovieSearch.Infrastructure.Vimeo;

public class VimeoApiResponse
{
    public IEnumerable<MovieVideoData> Data { get; set; }
}

public class MovieVideoData
{
    public string Uri { get; set; }
}