using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.Domain.Reviews.Queries.GetReviewById;
using MovieReview.Application.Domain.Reviews.Queries.GetReviews;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Reviews.Queries;

public class GetReviewByIdQueryHandler(MovieReviewDbContext dbContext)
    : IRequestHandler<GetReviewByIdQuery, ReviewDto>
{
    public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var review = await dbContext.Reviews
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken) ?? throw new KeyNotFoundException($"Review with id '{request.Id}' not found.");
        return new ReviewDto
        {
            Id = review.Id,
            MovieId = review.MovieId,
            UserId = review.UserId,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt
        };
    }
}
