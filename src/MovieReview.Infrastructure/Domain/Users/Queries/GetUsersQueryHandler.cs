using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.Common;
using MovieReview.Application.Domain.Users.Queries.GetUsers;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Users.Queries;

public class GetUsersQueryHandler(MovieReviewDbContext dbContext)
        : IRequestHandler<GetUsersQuery, PageResponse<List<UserDto>>>
{
    public async Task<PageResponse<List<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Users.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.UserName)) query = query.Where(u => u.UserName.Contains(request.UserName));

        if (!string.IsNullOrWhiteSpace(request.Email)) query = query.Where(u => u.Email.Contains(request.Email));

        var total = await query.CountAsync(cancellationToken);

        var users = await query
                .OrderBy(u => u.UserName)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email
                })
                .ToListAsync(cancellationToken);

        return new PageResponse<List<UserDto>>
        {
            Count = total,
            Data = users
        };
    }
}
