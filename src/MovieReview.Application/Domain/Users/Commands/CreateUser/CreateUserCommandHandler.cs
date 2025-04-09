using MediatR;
using MovieReview.Core.Common;
using MovieReview.Core.Domain.Users.Common;
using MovieReview.Core.Domain.Users.Models;
using MovieReview.Core.Domain.Users.Rules;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Application.Domain.Users.Commands.CreateUser;

public class CreateUserCommandHandler(
    MovieReviewDbContext dbContext,
    IUserEmailUniquenessChecker emailChecker)
    : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await Entity.CheckRuleAsync(new UserEmailMustBeUniqueRule(request.Data.Email, emailChecker), cancellationToken);

        var user = new User(request.Data.UserName, request.Data.Email);

        await dbContext.Users.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
