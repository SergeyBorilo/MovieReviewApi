using MovieReview.Core.Domain.Reviews.Models;

namespace MovieReview.Core.Domain.Reviews.Common;

public interface IReviewsRepository
{
    public Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task AddAsync(Review review, CancellationToken cancellationToken = default);
    public void Remove(Review review);
    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    public IQueryable<Review> Query();
}
