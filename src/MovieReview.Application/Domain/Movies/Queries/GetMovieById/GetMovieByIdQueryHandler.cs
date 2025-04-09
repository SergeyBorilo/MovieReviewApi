using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.Domain.Movies.Queries.GetMovie;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Application.Domain.Movies.Queries.GetMovieById;

public class GetMovieByIdQueryHandler(MovieReviewDbContext dbContext)
    : IRequestHandler<GetMovieByIdQuery, MovieDto?>
{
    public async Task<MovieDto?> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await dbContext.Movies
            .Where(m => m.Id == request.Id)
            .Select(m => new MovieDto(m.Id, m.Title, m.Genre, m.Year, m.Description, m.Reviews.Count))
            .FirstOrDefaultAsync(cancellationToken);

        return movie;
    }
}
