using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Users.Common;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Users.Common;

public class UserReviewExistenceChecker(MovieReviewDbContext dbContext) : IUserReviewExistenceChecker
{
    public Task<bool> HasReviewsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return dbContext.Reviews.AnyAsync(r => r.UserId == userId, cancellationToken);
    }
}
