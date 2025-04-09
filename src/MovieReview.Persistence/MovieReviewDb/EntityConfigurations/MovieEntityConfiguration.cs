using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Core.Domain.Movies.Models;

namespace MovieReview.Persistence.MovieReviewDb.EntityConfigurations;

public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.Property(m => m.Id)
            .IsRequired();

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Genre)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.Year)
            .IsRequired();

        builder.Property(m => m.Description)
            .HasMaxLength(1000);

        builder.Property(m => m.CreatedAt)
            .IsRequired();

        builder.HasMany(m => m.Reviews)
            .WithOne(r => r.Movie)
            .HasForeignKey(r => r.MovieId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
