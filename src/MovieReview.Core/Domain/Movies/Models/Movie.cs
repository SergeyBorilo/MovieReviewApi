using MovieReview.Core.Common;
using MovieReview.Core.Domain.Movies.Data;
using MovieReview.Core.Domain.Movies.Validator;
using MovieReview.Core.Domain.Reviews.Models;

namespace MovieReview.Core.Domain.Movies.Models;

public class Movie : Entity
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string Genre { get; private set; } = null!;
    public int Year { get; private set; }
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<Review> Reviews { get; set; } = [];

    private Movie() { }

    public static Movie Create(string title, string genre, int year, string? description)
    {
        var data = new CreateMovieData(title, genre, year, description);
        Validate(new CreateMovieValidator(), data);

        return new Movie
        {
            Id = Guid.NewGuid(),
            Title = title,
            Genre = genre,
            Year = year,
            Description = description,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Update(string title, string genre, int year, string? description)
    {
        Title = title;
        Genre = genre;
        Year = year;
        Description = description;
    }
}
