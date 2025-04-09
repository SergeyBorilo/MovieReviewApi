namespace MovieReview.Core.Common;

public interface IBuisnessRuleAsync
{
    public Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default);
}
