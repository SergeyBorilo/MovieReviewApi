namespace MovieReview.Core.Domain.Users.Common;

public interface IUserEmailUniquenessChecker
{
    public Task<bool> IsUniqueAsync(string email, CancellationToken cancellationToken = default);
}
