using MassTransit;
using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Movies.Models;
using MovieReview.Core.Domain.Reviews.Models;
using MovieReview.Core.Domain.Users.Models;
using MovieReview.Persistence.MovieReviewDb.EntityConfigurations;

namespace MovieReview.Persistence.MovieReviewDb;

public class MovieReviewDbContext : DbContext
{
    public const string UniDbSchema = "movieReview";

    public const string UniDbMigrationsHistoryTable = "MigrationsHistory";


    public DbSet<Movie> Movies { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<User> Users { get; set; }

    public MovieReviewDbContext(DbContextOptions<MovieReviewDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // todo: do it only for local development
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema(UniDbSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieReviewDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }
}
