namespace MovieReview.Core.Common;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken);

}
