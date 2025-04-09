using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Api.Domain.Reviews.Request;
using MovieReview.Application.Common;
using MovieReview.Application.Domain.Reviews.Commands.AddReview;
using MovieReview.Application.Domain.Reviews.Commands.DeleteReview;
using MovieReview.Application.Domain.Reviews.Commands.UpdateReview;
using MovieReview.Application.Domain.Reviews.Queries.GetReviewById;
using MovieReview.Application.Domain.Reviews.Queries.GetReviews;
using MovieReview.Core.Domain.Reviews.Data;

namespace MovieReview.Api.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<List<ReviewDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReviews(
        [FromQuery] GetReviewsQuery query,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReviewDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetReviewById(
        [FromRoute][Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetReviewByIdQuery(id);
        var review = await mediator.Send(query, cancellationToken);

        return Ok(review);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddReview(
        [FromBody] AddReviewRequest request,
        CancellationToken cancellationToken)
    {
        var command = new AddReviewCommand(
            request.MovieId,
            request.UserId,
            request.Rating,
            request.Comment
        );

        var id = await mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateReview(
        [FromRoute] Guid id,
        [FromBody] UpdateReviewData data,
        CancellationToken cancellationToken)
    {
        data.Id = id;
        await mediator.Send(new UpdateReviewCommand(data), cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteReview(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteReviewCommand(id), cancellationToken);
        return NoContent();
    }
}
