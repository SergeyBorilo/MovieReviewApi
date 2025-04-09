using FluentValidation;
using FluentValidation.Results;
using MovieReview.Core.Domain.Movies.Rules;
using MovieReview.Core.Domain.Reviews.Rules;
using MovieReview.Core.Domain.Users.Rules;
using MovieReview.Core.Exceptions;
using ValidationException = MovieReview.Core.Exceptions.ValidationException;

namespace MovieReview.Core.Common;

public abstract class Entity
{
    public static async Task CheckRuleAsync(ReviewTitleMustBeUniqueRule reviewTitleMustBeUniqueRule, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public static void Validate<T>(AbstractValidator<T> validator, T data)
    {
        var validationResult = validator.Validate(data);
        ThrowIfNotValid(validationResult);
    }

    public static async Task ValidateAsync<T>(AbstractValidator<T> validator, T data, CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(data, cancellationToken);
        ThrowIfNotValid(validationResult);
    }


    protected static void CheckRule(IBuisnessRule rule)
    {
        var ruleResult = rule.Check();
        if (ruleResult.IsFailed) throw new RuleValidationException(ruleResult.Errors);
    }


    private static void ThrowIfNotValid(ValidationResult validationResult)
    {
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
    }
    protected static async Task CheckRuleAsync(IBuisnessRuleAsync rule, CancellationToken cancellationToken = default)
    {
        var ruleResult = await rule.CheckAsync(cancellationToken);
        if (ruleResult.IsFailed)
            throw new RuleValidationException(ruleResult.Errors);
    }

    public static async Task CheckRuleAsync(MovieTitleMustBeUniqueRule reviewTitleMustBeUniqueRule, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public static async Task CheckRuleAsync(UserEmailMustBeUniqueRule reviewTitleMustBeUniqueRule, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
