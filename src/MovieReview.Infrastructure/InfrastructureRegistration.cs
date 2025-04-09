using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MovieReview.Core.Common;
using MovieReview.Core.Domain.Movies.Common;
using MovieReview.Core.Domain.Reviews.Common;
using MovieReview.Core.Domain.Users.Common;
using MovieReview.Infrastructure.Common;
using MovieReview.Infrastructure.Domain.Movies.Common;
using MovieReview.Infrastructure.Domain.Reviews.Common;
using MovieReview.Infrastructure.Domain.Users.Common;

namespace MovieReview.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureRegistration(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        //UnitOfWork
        service.AddScoped<IUnitOfWork, UnitOfWork>();

        //Repository
        service.AddScoped<IMoviesRepository, MoviesRepository>();
        service.AddScoped<IReviewsRepository, ReviewsRepository>();
        service.AddScoped<IUsersRepository, UsersRepository>();

        //Checkers 
        service.AddScoped<IMovieTitleUniquenessChecker, MovieTitleUniquenessChecker>();
        service.AddScoped<IReviewTitleUniquenessChecker, ReviewTitleUniquenessChecker>();
        service.AddScoped<ICannotDeleteUserWithReviewsChecker, CannotDeleteUserWithReviewsChecker>();
        service.AddScoped<IUserEmailUniquenessChecker, UserEmailUniquenessChecker>();
        service.AddScoped<IUserReviewExistenceChecker, UserReviewExistenceChecker>();

        // http clients
        // service.Configure<SystemHttpClientsSettings>(configuration.GetSection(nameof(SystemHttpClientsSettings)));
        // var systemHttpClientsSettings = configuration.GetSection(nameof(SystemHttpClientsSettings)).Get<SystemHttpClientsSettings>()
        //                                 ?? throw new AggregateException($"Settings: '{nameof(SystemHttpClientsSettings)}' is not found in configurations.");
        // service.RegisterAuthorsHttpClient(systemHttpClientsSettings.Library);
        // service.RegisterBocksHttpClient(systemHttpClientsSettings.Library);
    }
}
