using MediatR;
using MovieReview.Application.Common;

namespace MovieReview.Application.Domain.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<PageResponse<List<UserDto>>>
{
    public string? UserName { get; init; }
    public string? Email { get; init; }

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
