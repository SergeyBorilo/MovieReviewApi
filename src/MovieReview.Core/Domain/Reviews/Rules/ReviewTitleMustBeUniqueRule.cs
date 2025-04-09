using MovieReview.Core.Common;
using MovieReview.Core.Domain.Reviews.Common;

namespace MovieReview.Core.Domain.Reviews.Rules;

public class ReviewTitleMustBeUniqueRule(
    Guid title,
    IReviewTitleUniquenessChecker checker) : IBuisnessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isUnique = await checker.IsUniqueAsync(title, cancellationToken);
        return isUnique
            ? RuleResult.Success()
            : RuleResult.Failed($"Review title '{title}' must be unique.");
    }
}
