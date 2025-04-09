using MovieReview.Core.Common;
using MovieReview.Core.Domain.Reviews.Models;

namespace MovieReview.Core.Domain.Users.Models;

public class User : Entity
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public ICollection<Review> Reviews { get; set; } = [];

    public User() { }

    public User(string userName, string email)
    {
        UserName = userName;
        Email = email;
    }

    public void Update(string userName, string email)
    {
        UserName = userName;
        Email = email;
    }

}
