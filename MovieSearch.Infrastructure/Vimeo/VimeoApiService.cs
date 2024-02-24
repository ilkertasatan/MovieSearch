using Flurl.Http;
using Microsoft.Extensions.Options;
using MovieSearch.Application.Services;
using MovieSearch.Domain.ValueObjects;
using MovieSearch.Infrastructure.Helpers;

namespace MovieSearch.Infrastructure.Vimeo;

public sealed class VimeoApiService(IOptions<VimeoApiOptions> options) : IVimeoApiService
{
    private readonly string _apiUrl = options.Value.ApiUrl;
    private readonly string _accessToken = options.Value.AccessToken;

    public async Task<IEnumerable<VideoUri>?> GetMovieVideosByAsync(string movieTitle)
    {
        var response = await HttpRetryPolicy
            .BuildRetryPolicy()
            .ExecuteAsync(() =>
                _apiUrl
                    .WithHeader("Accept", "application/vnd.vimeo.*+json;version=3.4")
                    .WithHeader("Authorization", $"Bearer {_accessToken}")
                    .SetQueryParams(new
                    {
                        query = movieTitle,
                        direction = "desc",
                        per_page = 10,
                        fields = "player_embed_url"
                    })
                    .GetJsonAsync<VimeoApiResponse>());

        return response.Data.Select(video => new VideoUri(video.Uri));
    }
}