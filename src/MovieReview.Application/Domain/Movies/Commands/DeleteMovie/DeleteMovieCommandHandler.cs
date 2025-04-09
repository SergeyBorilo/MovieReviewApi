using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Application.Domain.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandHandler(MovieReviewDbContext dbContext)
    : IRequestHandler<DeleteMovieCommand>
{
    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                    ?? throw new Exception("Movie not found");

        dbContext.Movies.Remove(movie);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
