using MediatR;
using MovieSearch.Application.Common.Interfaces;

namespace MovieSearch.Application.UseCases.MovieSearch;

public sealed class MovieSearchQueryHandler(
    IOmDbApiService omDbApiService,
    IVimeoApiService vimeoApiService) : IRequestHandler<MovieSearchQuery, IQueryResult>
{
    public async Task<IQueryResult> Handle(MovieSearchQuery request, CancellationToken cancellationToken)
    {
        var movie = await omDbApiService.GetMovieInfoByAsync(request.Title.ToString());
        if (!movie.Exists())
            return new MovieSearchQueryNotFoundResult();
        
        var videoUris = await vimeoApiService.GetMovieVideosByAsync(request.Title.ToString());
        movie.AddVideoUris(videoUris);
            
        return new MovieSearchQuerySuccessResult(movie);
    }
}