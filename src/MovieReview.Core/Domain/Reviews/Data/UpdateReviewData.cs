namespace MovieReview.Core.Domain.Reviews.Data;

public class UpdateReviewData
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;
}
