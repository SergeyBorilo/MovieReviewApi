using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Reviews.Common;
using MovieReview.Core.Domain.Reviews.Models;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Reviews.Common;

public class ReviewsRepository(MovieReviewDbContext dbContext) : IReviewsRepository
{
    public async Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Reviews
            .Include(r => r.Movie)
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task AddAsync(Review review, CancellationToken cancellationToken = default)
    {
        await dbContext.Reviews.AddAsync(review, cancellationToken);
    }

    public void Remove(Review review)
    {
        dbContext.Reviews.Remove(review);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Reviews.AnyAsync(r => r.Id == id, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Review> Query()
    {
        return dbContext.Reviews
            .Include(r => r.Movie)
            .Include(r => r.User);
    }
}
