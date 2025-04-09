using FluentValidation;
using MovieReview.Core.Domain.Users.Data;

namespace MovieReview.Core.Domain.Users.Validator;

public class CreateUserValidator : AbstractValidator<CreateUserData>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must be at most 100 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be valid.")
            .MaximumLength(100).WithMessage("Email must be at most 100 characters.");
    }
}
