namespace MovieReview.Core.Domain.Reviews.Common;

public interface IReviewTitleUniquenessChecker
{
    public Task<bool> IsUniqueAsync(Guid title, CancellationToken cancellationToken = default);
}
