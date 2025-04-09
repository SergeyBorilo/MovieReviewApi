using MediatR;
using MovieReview.Application.Domain.Movies.Queries.GetMovie;

namespace MovieReview.Application.Domain.Movies.Queries.GetMovieById;

public record GetMovieByIdQuery(Guid Id) : IRequest<MovieDto?>;
