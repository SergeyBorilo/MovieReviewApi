using MovieReview.Core.Domain.Movies.Models;

namespace MovieReview.Core.Domain.Movies.Common;

public interface IMoviesRepository
{
    public IQueryable<Movie> Query();

    public Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task AddAsync(Movie movie, CancellationToken cancellationToken = default);
    public void Remove(Movie movie);
    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
