using MediatR;
using MovieReview.Core.Common;
using MovieReview.Core.Domain.Movies.Common;
using MovieReview.Core.Domain.Movies.Models;
using MovieReview.Core.Domain.Movies.Rules;
using MovieReview.Core.Domain.Movies.Validator;

namespace MovieReview.Application.Domain.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler(
    IMoviesRepository moviesRepository,
    IMovieTitleUniquenessChecker titleChecker,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateMovieCommand, Guid>
{
    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var data = request.Data;

        await Entity.ValidateAsync(new CreateMovieValidator(), data, cancellationToken);

        await Entity.CheckRuleAsync(new MovieTitleMustBeUniqueRule(data.Title, titleChecker), cancellationToken);

        var movie = Movie.Create(
            title: data.Title,
            genre: data.Genre,
            year: data.Year,
            description: data.Description
        );

        await moviesRepository.AddAsync(movie, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
