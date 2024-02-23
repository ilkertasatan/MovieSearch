using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using MovieSearch.Application.Common.Interfaces;
using MovieSearch.Domain.ValueObjects;
using MovieSearch.Infrastructure.Helpers;

namespace MovieSearch.Infrastructure.Vimeo;

public sealed class VimeoApiService(IOptions<VimeoApiOptions> options) : IVimeoApiService
{
    private readonly string _apiUrl = options.Value.Url;
    private readonly string _apiKey = options.Value.ApiKey;
    
    public async Task<IEnumerable<VideoUri>> GetMovieVideosByAsync(string movieTitle)
    {
        var response = await HttpRetryPolicy
            .BuildRetryPolicy()
            .ExecuteAsync(() =>
                _apiUrl
                    .SetQueryParams(new
                    {
                        apikey = _apiKey,
                        t = movieTitle
                    })
                    .GetJsonAsync<VimeoApiResponse>());

        return response.Data.Select(video => new VideoUri(video.Uri));
    }
}