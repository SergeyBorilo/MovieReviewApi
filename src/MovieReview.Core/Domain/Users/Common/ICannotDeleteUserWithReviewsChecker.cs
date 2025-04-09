namespace MovieReview.Core.Domain.Users.Common;

public interface ICannotDeleteUserWithReviewsChecker
{
    public Task<bool> HasReviewsAsync(Guid userId, CancellationToken cancellationToken);
}
