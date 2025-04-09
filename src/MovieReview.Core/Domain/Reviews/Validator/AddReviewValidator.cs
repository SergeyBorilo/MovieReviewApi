using FluentValidation;
using MovieReview.Core.Domain.Reviews.Data;

namespace MovieReview.Core.Domain.Reviews.Validator;

public class AddReviewValidator : AbstractValidator<AddReviewData>
{
    public AddReviewValidator()
    {
        RuleFor(x => x.MovieId).NotEmpty().WithMessage("MovieId is required.");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 10)
            .WithMessage("Rating must be between 1 and 10.");
        RuleFor(x => x.Comment)
            .MaximumLength(1000)
            .WithMessage("Comment must not exceed 1000 characters.");
    }
}

