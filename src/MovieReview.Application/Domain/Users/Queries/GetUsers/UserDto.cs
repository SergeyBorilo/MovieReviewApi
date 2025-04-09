namespace MovieReview.Application.Domain.Users.Queries.GetUsers;

public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null;
    public string Email { get; set; } = null;

    public UserDto() { }
}
