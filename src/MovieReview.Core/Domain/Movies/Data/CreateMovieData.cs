namespace MovieReview.Core.Domain.Movies.Data;

public record CreateMovieData(string Title, string Genre, int Year, string? Description);
