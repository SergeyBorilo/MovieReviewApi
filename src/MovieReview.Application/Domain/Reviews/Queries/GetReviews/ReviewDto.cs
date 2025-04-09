namespace MovieReview.Application.Domain.Reviews.Queries.GetReviews;

public class ReviewDto
{
    public Guid Id { get; init; }
    public Guid MovieId { get; init; }
    public Guid UserId { get; init; }
    public int Rating { get; init; }
    public string Comment { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }

    public ReviewDto(Guid id, Guid movieId, Guid userId, int rating, string comment, DateTime createdAt)
    {
        Id = id;
        MovieId = movieId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedAt = createdAt;
    }

    public ReviewDto()
    {
    }
}
