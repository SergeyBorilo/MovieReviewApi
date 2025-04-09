namespace MovieReview.Core.Domain.Users.Common;

public interface IUserReviewExistenceChecker
{
    public Task<bool> HasReviewsAsync(Guid userId, CancellationToken cancellationToken);
}
