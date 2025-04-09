using MovieReview.Core.Common;
using MovieReview.Core.Domain.Movies.Common;

namespace MovieReview.Core.Domain.Movies.Rules;

public class MovieTitleMustBeUniqueRule(string title, IMovieTitleUniquenessChecker checker) : IBuisnessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isUnique = await checker.IsUniqueAsync(title, cancellationToken);
        return isUnique
            ? RuleResult.Success()
            : RuleResult.Failed($"Movie title '{title}' must be unique.");
    }
}
