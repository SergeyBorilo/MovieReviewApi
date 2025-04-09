using MediatR;

namespace MovieReview.Application.Domain.Reviews.Commands.DeleteReview;

public record DeleteReviewCommand(Guid ReviewId) : IRequest;
