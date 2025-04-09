namespace MovieReview.Api.Domain.Reviews.Request;

public class AddReviewRequest
{
    public Guid MovieId { get; set; }
    public Guid UserId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}
