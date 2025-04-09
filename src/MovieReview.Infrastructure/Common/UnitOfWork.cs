using MovieReview.Core.Common;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Common;

public class UnitOfWork(MovieReviewDbContext dbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
