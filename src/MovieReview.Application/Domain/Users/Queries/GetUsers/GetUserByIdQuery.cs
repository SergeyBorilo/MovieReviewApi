using MediatR;

namespace MovieReview.Application.Domain.Users.Queries.GetUsers;

public record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;
