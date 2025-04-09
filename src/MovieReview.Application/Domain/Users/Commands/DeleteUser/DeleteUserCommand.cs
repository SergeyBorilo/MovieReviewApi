using MediatR;

namespace MovieReview.Application.Domain.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid Id) : IRequest;

