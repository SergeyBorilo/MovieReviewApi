using MediatR;
using MovieReview.Application.Common;

namespace MovieReview.Application.Domain.Movies.Queries.GetMovie;

public class GetMoviesQuery : IRequest<PageResponse<List<MovieDto>>>
{
    public string? Genre { get; init; }
    public int? Year { get; init; }
    public int? Rating { get; init; }

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
