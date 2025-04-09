using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.Common;
using MovieReview.Application.Domain.Reviews.Queries.GetReviews;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Reviews.Queries;

public class GetReviewsQueryHandler(MovieReviewDbContext dbContext)
    : IRequestHandler<GetReviewsQuery, PageResponse<List<ReviewDto>>>
{
    public async Task<PageResponse<List<ReviewDto>>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Reviews.AsQueryable();

        if (request.MovieId.HasValue)
            query = query.Where(r => r.MovieId == request.MovieId.Value);

        if (request.UserId.HasValue)
            query = query.Where(r => r.UserId == request.UserId.Value);

        if (request.Rating.HasValue)
            query = query.Where(r => r.Rating == request.Rating.Value);

        var totalCount = await query.CountAsync(cancellationToken);

        var reviews = await query
            .OrderByDescending(r => r.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(r => new ReviewDto(
                r.Id,
                r.MovieId,
                r.UserId,
                r.Rating,
                r.Comment,
                r.CreatedAt))
            .ToListAsync(cancellationToken);

        return new PageResponse<List<ReviewDto>> { Count = totalCount, Data = reviews };
    }
}
