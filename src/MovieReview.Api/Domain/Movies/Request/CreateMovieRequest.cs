namespace MovieReview.Api.Domain.Movies.Request;

public class CreateMovieRequest
{
    public string Title { get; set; } = null;
    public string Genre { get; set; } = null;
    public int Year { get; set; }

    public string? Description { get; set; }
}
