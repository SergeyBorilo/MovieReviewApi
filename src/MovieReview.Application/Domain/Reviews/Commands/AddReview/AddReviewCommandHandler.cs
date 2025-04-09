using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Reviews.Models;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Application.Domain.Reviews.Commands.AddReview;

public class AddReviewCommandHandler(MovieReviewDbContext dbContext)
    : IRequestHandler<AddReviewCommand, Guid>
{
    public async Task<Guid> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
        var exists = await dbContext.Reviews.AnyAsync(r =>
            r.MovieId == request.MovieId && r.UserId == request.UserId, cancellationToken);

        if (exists) throw new InvalidOperationException("User has already submitted a review for this movie.");

        var review = Review.Create(request.MovieId, request.UserId, request.Comment, request.Rating);

        dbContext.Reviews.Add(review);
        await dbContext.SaveChangesAsync(cancellationToken);

        return review.Id;
    }
}
