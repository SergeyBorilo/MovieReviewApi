using MovieReview.Core.Common;
using MovieReview.Core.Domain.Users.Common;

namespace MovieReview.Core.Domain.Users.Rules;

public class UserEmailMustBeUniqueRule(string email, IUserEmailUniquenessChecker checker) : IBuisnessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {

        var isUnique = await checker.IsUniqueAsync(email, cancellationToken);
        return isUnique
            ? RuleResult.Success()
            : RuleResult.Failed($"User email '{email}' must be unique.");
    }
}
