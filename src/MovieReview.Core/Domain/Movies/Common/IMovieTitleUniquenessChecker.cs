namespace MovieReview.Core.Domain.Movies.Common;

public interface IMovieTitleUniquenessChecker
{
    public Task<bool> IsUniqueAsync(string title, CancellationToken cancellationToken = default);
}
