namespace MovieReview.Core.Domain.Users.Data;

public class UpdateUserData
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = null!;
    public string Email { get; init; } = null!;
}
