using MovieSearch.Domain.Movies;
using MovieSearch.Domain.ValueObjects;
using MovieSearch.Infrastructure.Services.OmDb;

namespace MovieSearch.Infrastructure.Extensions;

public static class OmDbApiResponseExtensions
{
    public static Movie ToEntity(this OmDbApiResponse response)
    {
        return Movie.New(
            new MovieId(response.ImdbId),
            new Title(response.Title),
            new Year(response.Year),
            Genre.Parse(response.Genre),
            Director.Parse(response.Director),
            Writer.Parse(response.Writer),
            Actor.Parse(response.Actors),
            new Plot(response.Plot),
            Language.Parse(response.Language));
    }
}