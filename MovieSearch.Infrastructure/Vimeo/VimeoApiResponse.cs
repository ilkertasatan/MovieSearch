using System.Text.Json.Serialization;

namespace MovieSearch.Infrastructure.Vimeo;

public class VimeoApiResponse
{
    public IEnumerable<MovieVideoData> Data { get; set; }
}

public class MovieVideoData
{
    [JsonPropertyName("player_embed_url")]
    public string Uri { get; set; }
}