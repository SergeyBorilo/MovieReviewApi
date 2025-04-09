using MediatR;
using MovieReview.Application.Domain.Reviews.Queries.GetReviews;

namespace MovieReview.Application.Domain.Reviews.Queries.GetReviewById;

public record GetReviewByIdQuery(Guid Id) : IRequest<ReviewDto>;
