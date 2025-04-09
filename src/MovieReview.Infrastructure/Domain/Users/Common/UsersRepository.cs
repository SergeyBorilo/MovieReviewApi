using Microsoft.EntityFrameworkCore;
using MovieReview.Application.Common;
using MovieReview.Application.Domain.Users.Queries.GetUsers;
using MovieReview.Core.Domain.Users.Common;
using MovieReview.Core.Domain.Users.Models;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Users.Common;

public class UsersRepository(MovieReviewDbContext dbContext) : IUsersRepository
{
    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Users
            .Where(u => u.Id == id)
            .Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            })
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PageResponse<List<UserDto>>> GetUsersAsync(string? email, string? userName, int pageNumber,
        int pageSize, CancellationToken cancellationToken)
    {
        var query = dbContext.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(u => u.Email.Contains(email));

        if (!string.IsNullOrWhiteSpace(userName))
            query = query.Where(u => u.UserName.Contains(userName));

        var count = await query.CountAsync(cancellationToken);

        var users = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            })
            .ToListAsync(cancellationToken);

        return new PageResponse<List<UserDto>>
        {
            Count = count,
            Data = users
        };
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        return !await dbContext.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.Users.AnyAsync(u => u.Id == userId, cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await dbContext.Users.AddAsync(user, cancellationToken);
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        dbContext.Users.Remove(user);
    }
}
