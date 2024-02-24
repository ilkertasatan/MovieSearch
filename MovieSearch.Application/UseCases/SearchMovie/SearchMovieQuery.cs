using ErrorOr;
using MediatR;
using MovieSearch.Domain.Movies;
using MovieSearch.Domain.ValueObjects;

namespace MovieSearch.Application.UseCases.SearchMovie;

public sealed record SearchMovieQuery(string MovieTitle) : IRequest<ErrorOr<Movie>>
{
    public Title Title { get; set; } = new(MovieTitle);
}