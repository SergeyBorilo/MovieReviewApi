namespace MovieReview.Api.Domain.Users.Request;

public class RegisterUserRequest
{
    public string UserName { get; set; } = null;
    public string Email { get; set; } = null;
}
