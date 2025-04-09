using MediatR;
using MovieReview.Core.Domain.Reviews.Data;

namespace MovieReview.Application.Domain.Reviews.Commands.UpdateReview;

public record UpdateReviewCommand(UpdateReviewData Data) : IRequest;
