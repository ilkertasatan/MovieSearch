using ErrorOr;
using MediatR;
using MovieSearch.Application.Services;
using MovieSearch.Domain.Movies;

namespace MovieSearch.Application.UseCases.SearchMovie;

public sealed class SearchMovieQueryHandler(
    IOmDbApiService omDbApiService,
    IVimeoApiService vimeoApiService) : IRequestHandler<SearchMovieQuery, ErrorOr<Movie>>
{
    public async Task<ErrorOr<Movie>> Handle(SearchMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await omDbApiService.GetMovieInfoByAsync(request.MovieTitle);
        if (!movie.Exists())
        {
            return Error.NotFound(description: "Movie not found");
        }

        var videoUris = await vimeoApiService.GetMovieVideosByAsync(request.MovieTitle);
        movie.AddVideoUris(videoUris);

        return movie;
    }
}