using MediatR;
using MovieReview.Core.Domain.Users.Data;

namespace MovieReview.Application.Domain.Users.Commands.CreateUser;

public record CreateUserCommand(CreateUserData Data) : IRequest<Guid>;
