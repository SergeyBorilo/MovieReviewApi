using MovieReview.Core.Domain.Users.Models;

namespace MovieReview.Core.Domain.Users.Common;

public interface IUsersRepository
{
    public Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken);
    public Task<bool> ExistsAsync(Guid userId, CancellationToken cancellationToken);
    public Task AddAsync(User user, CancellationToken cancellationToken);
    public Task DeleteAsync(User user, CancellationToken cancellationToken);
}
