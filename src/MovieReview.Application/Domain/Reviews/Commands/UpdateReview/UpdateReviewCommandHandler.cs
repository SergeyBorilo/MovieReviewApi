using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Common;
using MovieReview.Core.Domain.Reviews.Common;
using MovieReview.Core.Domain.Reviews.Rules;
using MovieReview.Core.Domain.Reviews.Validator;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Application.Domain.Reviews.Commands.UpdateReview;

public class UpdateReviewCommandHandler(
    MovieReviewDbContext dbContext,
    IReviewTitleUniquenessChecker titleChecker)
    : IRequestHandler<UpdateReviewCommand>
{
    public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == request.Data.Id, cancellationToken) ?? throw new KeyNotFoundException($"Review with id '{request.Data.Id}' not found.");
        if (!string.Equals(review.Title, request.Data.Title, StringComparison.OrdinalIgnoreCase))
        {
            await Entity.CheckRuleAsync(new ReviewTitleMustBeUniqueRule(request.Data.Id, titleChecker),
                cancellationToken);
        }

        review.Update(request.Data.Title, request.Data.Rating, request.Data.Comment);

        await new UpdateReviewValidator().ValidateAndThrowAsync(request.Data, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

}
