using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.Common;
using MovieReview.Application.Domain.Movies.Queries.GetMovie;
using MovieReview.Persistence.MovieReviewDb;

namespace MovieReview.Infrastructure.Domain.Movies.Queries;

public class GetMoviesQueryHandler(MovieReviewDbContext dbContext)
    : IRequestHandler<GetMoviesQuery, PageResponse<List<MovieDto>>>
{
    public async Task<PageResponse<List<MovieDto>>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Movies.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Genre))
            query = query.Where(m => m.Genre == request.Genre);

        if (request.Year.HasValue)
            query = query.Where(m => m.Year == request.Year);

        if (request.Rating.HasValue)
            query = query.Where(m => m.Reviews.Average(r => r.Rating) >= request.Rating);

        var count = await query.CountAsync(cancellationToken);

        var movies = await query
            .OrderByDescending(m => m.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(m => new MovieDto(m.Id, m.Title, m.Genre, m.Year, m.Description, m.Reviews.Count))
            .ToListAsync(cancellationToken);

        return new PageResponse<List<MovieDto>> { Count = count, Data = movies };
    }
}

