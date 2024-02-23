using MediatR;

namespace MovieSearch.Application.UseCases.MovieSearch;

public sealed class MovieSearchQueryHandler : IRequestHandler<MovieSearchQuery, MovieSearchQueryResult>
{
    public Task<MovieSearchQueryResult> Handle(MovieSearchQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}