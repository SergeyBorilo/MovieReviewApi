using MediatR;

namespace MovieReview.Application.Domain.Movies.Commands.UpdateMovie;

public record UpdateMovieCommand(Guid Id, string Title, string Genre, int Year, string? Description) : IRequest;
