using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Persistence;

public static class PersistenceRegistration
{
    private const string ConnectionStringName = "MovieReviewDb";

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName);

        services.AddDbContext<MovieReviewDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        MovieReviewDbContext.UniDbMigrationsHistoryTable,
                        MovieReviewDbContext.UniDbSchema);
                });
        });
    }
}
