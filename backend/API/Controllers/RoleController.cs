using API.Controllers.Abstractions;
using Application.Features.Identity.Commands.CreateRole;
using Application.Features.Identity.Queries.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RoleController : ApiController
{
    public RoleController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        => Ok(await _mediator.Send(command));

    [HttpGet]
    public async Task<IActionResult> GetRoles()
        => Ok(await _mediator.Send(new GetRolesQuery()));
}
