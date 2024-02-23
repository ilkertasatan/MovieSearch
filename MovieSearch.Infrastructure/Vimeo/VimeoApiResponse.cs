namespace MovieSearch.Infrastructure.Vimeo;

public class VimeoApiResponse
{
    public IEnumerable<MovieVideoData> Data { get; set; }
}

public class MovieVideoData
{
    public string Uri { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
}