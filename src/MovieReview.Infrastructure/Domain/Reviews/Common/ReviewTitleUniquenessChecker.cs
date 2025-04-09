using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Reviews.Common;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Reviews.Common;

public class ReviewTitleUniquenessChecker(MovieReviewDbContext dbContext)
    : IReviewTitleUniquenessChecker
{
    public async Task<bool> IsUniqueAsync(string title, CancellationToken cancellationToken = default)
    {
        return !await dbContext.Reviews
            .AnyAsync(r => r.Title == title, cancellationToken);
    }

    public Task<bool> IsUniqueAsync(Guid title, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
