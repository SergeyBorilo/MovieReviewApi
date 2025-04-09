using MovieReview.Core.Common;
using MovieReview.Core.Domain.Users.Common;

namespace MovieReview.Core.Domain.Users.Rules;

public class CannotDeleteUserWithReviewsRule(Guid userId, IUserReviewExistenceChecker checker) : IBuisnessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var hasReviews = await checker.HasReviewsAsync(userId, cancellationToken);
        return hasReviews
            ? RuleResult.Failed($"Cannot delete user with id '{userId}' because they have reviews.")
            : RuleResult.Success();
    }
}
