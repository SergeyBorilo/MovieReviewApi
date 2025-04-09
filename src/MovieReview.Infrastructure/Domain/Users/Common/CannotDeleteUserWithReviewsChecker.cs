using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Users.Common;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Users.Common;

public class CannotDeleteUserWithReviewsChecker(MovieReviewDbContext dbContext)
    : ICannotDeleteUserWithReviewsChecker
{
    public async Task<bool> HasReviewsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.Reviews
            .AnyAsync(r => r.UserId == userId, cancellationToken);
    }
}
