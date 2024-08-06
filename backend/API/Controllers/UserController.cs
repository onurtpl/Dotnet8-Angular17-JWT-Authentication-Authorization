using API.Controllers.Abstractions;
using Application.Features.Identity.Commands.AssignRole;
using Application.Features.Identity.Commands.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Controllers;

[Authorize]
public class UserController : ApiController
{
    public UserController(IMediator mediator) : base(mediator) { }

    //[Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetUsers(GetUsersCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("[action]")]
    public async Task<IActionResult> AssignRole(AssignRoleCommand command)
        => Ok(await _mediator.Send(command));

}
