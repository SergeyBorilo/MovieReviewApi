namespace MovieReview.Core.Domain.Reviews.Data;

public record AddReviewData(Guid MovieId, Guid UserId, int Rating, string Comment);
