using MediatR;

namespace MovieReview.Application.Domain.Reviews.Commands.AddReview;

public record AddReviewCommand(Guid MovieId, Guid UserId, int Rating, string Comment) : IRequest<Guid>;
