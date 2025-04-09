using MediatR;
using MovieReview.Core.Domain.Movies.Data;

namespace MovieReview.Application.Domain.Movies.Commands.CreateMovie;

public record CreateMovieCommand(CreateMovieData Data) : IRequest<Guid>;
