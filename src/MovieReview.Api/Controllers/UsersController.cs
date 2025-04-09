using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Application.Common;
using MovieReview.Application.Domain.Users.Commands.CreateUser;
using MovieReview.Application.Domain.Users.Commands.DeleteUser;
using MovieReview.Application.Domain.Users.Commands.UpdateUser;
using MovieReview.Application.Domain.Users.Queries.GetUsers;
using MovieReview.Core.Domain.Users.Data;

namespace MovieReview.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<List<UserDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsers(
        [FromQuery] string? name,
        [FromQuery] string? email,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetUsersQuery
        {
            UserName = name,
            Email = email,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var users = await mediator.Send(query, cancellationToken);
        return Ok(users);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById(
        [FromRoute][Required] Guid id,
        CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserData request,
        CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(request);
        var userId = await mediator.Send(command, cancellationToken);
        return Ok(userId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateUser(
        [FromBody][Required] UpdateUserData data,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateUserCommand(data), cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUser(
        [FromRoute][Required] Guid id,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserCommand(id), cancellationToken);
        return NoContent();
    }

}
