using MovieReview.Core.Common;
using MovieReview.Core.Domain.Movies.Models;
using MovieReview.Core.Domain.Reviews.Data;
using MovieReview.Core.Domain.Reviews.Validator;
using MovieReview.Core.Domain.Users.Models;

namespace MovieReview.Core.Domain.Reviews.Models;
public class Review : Entity
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Movie Movie { get; set; }
    public string Comment { get; set; } = null!;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }

    public Review() { }

    public static Review Create(Guid movieId, Guid userId, string comment, int rating)
    {
        Validate(new AddReviewValidator(), new AddReviewData(movieId, userId, rating, comment));

        return new Review
        {
            Id = Guid.NewGuid(),
            MovieId = movieId,
            UserId = userId,
            Comment = comment,
            Rating = rating,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Update(string title, int rating, string comment)
    {
        Title = title;
        Rating = rating;
        Comment = comment;
        UpdatedAt = DateTime.UtcNow;
    }
}

