using MediatR;

namespace MovieReview.Application.Domain.Movies.Commands.DeleteMovie;

public record DeleteMovieCommand(Guid Id) : IRequest;
