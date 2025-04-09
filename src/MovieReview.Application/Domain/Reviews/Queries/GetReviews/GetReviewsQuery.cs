using MediatR;
using MovieReview.Application.Common;

namespace MovieReview.Application.Domain.Reviews.Queries.GetReviews;

public class GetReviewsQuery : IRequest<PageResponse<List<ReviewDto>>>
{
    public Guid? MovieId { get; init; }
    public Guid? UserId { get; init; }
    public int? Rating { get; init; }

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
