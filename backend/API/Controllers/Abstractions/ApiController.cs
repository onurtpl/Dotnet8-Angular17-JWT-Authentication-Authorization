using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abstractions;

[Route("api/[controller]")]
[ApiController]
public class ApiController: ControllerBase
{
    protected readonly IMediator _mediator;

    public ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
