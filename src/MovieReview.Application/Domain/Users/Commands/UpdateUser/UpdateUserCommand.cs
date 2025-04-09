using MediatR;
using MovieReview.Core.Domain.Users.Data;

namespace MovieReview.Application.Domain.Users.Commands.UpdateUser;

public record UpdateUserCommand(UpdateUserData Data) : IRequest<Guid>, IRequest;
