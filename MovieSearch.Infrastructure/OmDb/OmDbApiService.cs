using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using MovieSearch.Application.Common.Interfaces;
using MovieSearch.Application.Common.Models;
using MovieSearch.Infrastructure.Helpers;

namespace MovieSearch.Infrastructure.OmDb;

public sealed class OmDbApiService(IOptions<OmDbApiOptions> options) : IOmDbApiService
{
    private readonly string _apiUrl = options.Value.Url;
    private readonly string _apiKey = options.Value.ApiKey;
    
    public async Task<MovieInfo> GetMovieInfoByAsync(string movieTitle)
    {
        return await HttpRetryPolicy
            .BuildRetryPolicy()
            .ExecuteAsync(() =>
                _apiUrl
                    .SetQueryParams(new
                    {
                        apikey = _apiKey,
                        t = movieTitle
                    })
                    .GetJsonAsync<MovieInfo>());
    }
}