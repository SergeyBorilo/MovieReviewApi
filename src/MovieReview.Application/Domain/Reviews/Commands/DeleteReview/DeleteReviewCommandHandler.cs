using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Application.Domain.Reviews.Commands.DeleteReview;

public class DeleteReviewCommandHandler(MovieReviewDbContext dbContext)
    : IRequestHandler<DeleteReviewCommand>
{
    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == request.ReviewId, cancellationToken) ?? throw new KeyNotFoundException($"Review with id '{request.ReviewId}' not found.");
        dbContext.Reviews.Remove(review);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
