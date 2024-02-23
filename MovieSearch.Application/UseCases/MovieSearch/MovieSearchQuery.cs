using MediatR;
using MovieSearch.Domain.ValueObjects;

namespace MovieSearch.Application.UseCases.MovieSearch;

public sealed class MovieSearchQuery(string title) : IRequest<MovieSearchQueryResult>
{
    public Title Title { get; set; } = new(title);
}