using FluentValidation;
using MovieReview.Core.Domain.Users.Data;

namespace MovieReview.Core.Domain.Users.Validator;

public class UpdateUserValidator : AbstractValidator<UpdateUserData>
{
    public UpdateUserValidator()
    {
        RuleFor(u => u.Id).NotEmpty();
        RuleFor(u => u.UserName).NotEmpty().MaximumLength(100);
        RuleFor(u => u.Email).NotEmpty().EmailAddress().MaximumLength(100);
    }
}
