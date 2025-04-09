using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Api.Domain.Movies.Request;
using MovieReview.Application.Common;
using MovieReview.Application.Domain.Movies.Commands.CreateMovie;
using MovieReview.Application.Domain.Movies.Commands.DeleteMovie;
using MovieReview.Application.Domain.Movies.Commands.UpdateMovie;
using MovieReview.Application.Domain.Movies.Queries.GetMovie;
using MovieReview.Application.Domain.Movies.Queries.GetMovieById;
using MovieReview.Core.Domain.Movies.Data;

namespace MovieReview.Api.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<List<MovieDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMovies(
        [FromQuery] string? genre,
        [FromQuery] int? year,
        [FromQuery] int? rating,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetMoviesQuery
        {
            Genre = genre,
            Year = year,
            Rating = rating,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(MovieDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMovieById(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetMovieByIdQuery(id), cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateMovie(
        [FromBody] CreateMovieData request,
        CancellationToken cancellationToken)
    {
        var command = new CreateMovieCommand(request);
        var id = await mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateMovie(
        [FromRoute] Guid id,
        [FromBody] CreateMovieRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateMovieCommand(id, request.Title, request.Genre, request.Year, request.Description);
        await mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteMovie(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteMovieCommand(id), cancellationToken);
        return Ok(id);
    }
}
