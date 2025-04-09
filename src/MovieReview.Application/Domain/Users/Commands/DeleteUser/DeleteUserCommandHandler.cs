using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Common;
using MovieReview.Core.Domain.Reviews.Common;
using MovieReview.Core.Domain.Reviews.Rules;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Application.Domain.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(
    MovieReviewDbContext dbContext,
    IReviewTitleUniquenessChecker checker)
    : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await Entity.CheckRuleAsync(
            new ReviewTitleMustBeUniqueRule(request.Id, checker),
            cancellationToken);

        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken) ?? throw new KeyNotFoundException($"User with id '{request.Id}' not found.");
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
