using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Common;
using MovieReview.Core.Domain.Reviews.Common;
using MovieReview.Core.Domain.Reviews.Rules;
using MovieReview.Core.Domain.Users.Validator;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Application.Domain.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(MovieReviewDbContext dbContext,
    IReviewTitleUniquenessChecker emailChecker)
    : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Data.Id, cancellationToken) ?? throw new KeyNotFoundException($"User with id '{request.Data.Id}' not found.");
        if (!string.Equals(user.Email, request.Data.Email, StringComparison.OrdinalIgnoreCase))
        {
            await Entity.CheckRuleAsync(
                new ReviewTitleMustBeUniqueRule(request.Data.Id, emailChecker),
                cancellationToken);
        }

        await new UpdateUserValidator().ValidateAndThrowAsync(request.Data, cancellationToken);

        user.Update(request.Data.UserName, request.Data.Email);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
