using FluentValidation;
using MovieReview.Core.Domain.Movies.Data;

namespace MovieReview.Core.Domain.Movies.Validator;

public class CreateMovieValidator : AbstractValidator<CreateMovieData>
{
    public CreateMovieValidator()
    {
        RuleFor(m => m.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(m => m.Genre)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.Year)
            .InclusiveBetween(1900, DateTime.UtcNow.Year);

        RuleFor(m => m.Description)
            .MaximumLength(1000).When(m => m.Description != null);
    }
}
