using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Common;
using MovieReview.Core.Domain.Movies.Data;
using MovieReview.Core.Domain.Movies.Validator;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Application.Domain.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler(MovieReviewDbContext dbContext)
    : IRequestHandler<UpdateMovieCommand>
{
    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                    ?? throw new Exception("Movie not found");

        var data = new CreateMovieData(request.Title, request.Genre, request.Year, request.Description);
        await Entity.ValidateAsync(new CreateMovieValidator(), data, cancellationToken);

        movie.Update(request.Title, request.Genre, request.Year, request.Description);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
