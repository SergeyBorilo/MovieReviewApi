using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Movies.Common;
using MovieReview.Core.Domain.Movies.Models;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Movies.Common;

public class MoviesRepository(MovieReviewDbContext dbContext) : IMoviesRepository
{
    public IQueryable<Movie> Query()
    {
        return dbContext.Movies.Include(m => m.Reviews);
    }

    public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Movies
            .Include(m => m.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task AddAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        await dbContext.Movies.AddAsync(movie, cancellationToken);
    }

    public void Remove(Movie movie)
    {
        dbContext.Movies.Remove(movie);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Movies.AnyAsync(m => m.Id == id, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
