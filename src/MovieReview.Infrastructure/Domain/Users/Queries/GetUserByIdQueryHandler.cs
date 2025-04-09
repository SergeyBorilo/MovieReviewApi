using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.Domain.Users.Queries.GetUsers;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Users.Queries;

public class GetUserByIdQueryHandler(MovieReviewDbContext dbContext)
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken) ?? throw new KeyNotFoundException($"User with id '{request.Id}' not found.");
        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email
        };
    }
}
