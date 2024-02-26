using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using MovieSearch.Application.Services;
using MovieSearch.Domain.Movies;
using MovieSearch.Infrastructure.Extensions;
using MovieSearch.Infrastructure.Helpers;

namespace MovieSearch.Infrastructure.Services.OmDb;

public sealed class OmDbApiService(IOptions<OmDbApiOptions> options) : IOmDbApiService
{
    private readonly string _apiUrl = options.Value.ApiUrl;
    private readonly string _apiKey = options.Value.ApiKey;

    public async Task<Movie?> GetMovieInfoByAsync(string movieTitle)
    {
        return (await HttpRetryPolicy
                .BuildRetryPolicy()
                .ExecuteAsync(() =>
                    _apiUrl
                        .SetQueryParams(new
                        {
                            apikey = _apiKey,
                            t = movieTitle
                        })
                        .GetJsonAsync<OmDbApiResponse>())).ToEntity();
    }
}