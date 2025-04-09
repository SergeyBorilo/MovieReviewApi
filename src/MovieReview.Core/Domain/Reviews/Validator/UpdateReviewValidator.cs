using FluentValidation;
using MovieReview.Core.Domain.Reviews.Data;

namespace MovieReview.Core.Domain.Reviews.Validator;

public class UpdateReviewValidator : AbstractValidator<UpdateReviewData>
{
    public UpdateReviewValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage("Review ID is required.");

        RuleFor(r => r.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must be at most 100 characters.");

        RuleFor(r => r.Rating)
            .InclusiveBetween(1, 10).WithMessage("Rating must be between 1 and 10.");

        RuleFor(r => r.Comment)
            .MaximumLength(1000).WithMessage("Comment must be at most 1000 characters.");
    }
}
