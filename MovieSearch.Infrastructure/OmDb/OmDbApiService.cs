using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using MovieSearch.Application.Services;
using MovieSearch.Domain.Movies;
using MovieSearch.Domain.ValueObjects;
using MovieSearch.Infrastructure.Helpers;

namespace MovieSearch.Infrastructure.OmDb;

public sealed class OmDbApiService(IOptions<OmDbApiOptions> options) : IOmDbApiService
{
    private readonly string _apiUrl = options.Value.Url;
    private readonly string _apiKey = options.Value.ApiKey;
    
    public async Task<Movie> GetMovieInfoByAsync(string movieTitle)
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
                    .GetJsonAsync<OmDbApiResponse>());

        return Movie.New(
            new MovieId(response.ImdbId),
            new Title(response.Title),
            new Year(response.Year),
            Genre.Parse(response.Genre),
            Director.Parse(response.Director),
            Writer.Parse(response.Writer),
            Actor.Parse(response.Actors),
            new Plot(response.Plot),
            Language.Parse(response.Languages));
    }
}