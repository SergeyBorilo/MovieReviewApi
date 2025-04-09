using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Users.Common;
using MovieReview.Persistence.MovieReviewDb;
namespace MovieReview.Infrastructure.Domain.Users.Common;

public class UserEmailUniquenessChecker(MovieReviewDbContext dbContext) : IUserEmailUniquenessChecker
{
    public async Task<bool> IsUniqueAsync(string email, CancellationToken cancellationToken = default)
    {
        return !await dbContext.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower(), cancellationToken);
    }
}
