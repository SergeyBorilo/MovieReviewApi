using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Movies.Common;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Movies.Common;

public class MovieTitleUniquenessChecker(MovieReviewDbContext dbContext) : IMovieTitleUniquenessChecker
{
    public async Task<bool> IsUniqueAsync(string title, CancellationToken cancellationToken = default)
    {
        return !await dbContext.Movies.AnyAsync(m => m.Title == title, cancellationToken);
    }
}
