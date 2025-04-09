namespace MovieReview.Application.Domain.Movies.Queries.GetMovie;

public class MovieDto(
    Guid id,
    string title,
    string genre,
    int year,
    string? description = null,
    double? averageRating = null)
{
    public Guid Id { get; init; } = id;
    public string Title { get; init; } = title;
    public string Genre { get; init; } = genre;
    public int Year { get; init; } = year;
    public string? Description { get; init; } = description;
    public double? AverageRating { get; init; } = averageRating;
}
