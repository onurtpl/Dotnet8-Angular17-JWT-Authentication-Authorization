using API.Controllers.Abstractions;
using Application.Features.Identity.Commands.ForgotPassword;
using Application.Features.Identity.Commands.Login;
using Application.Features.Identity.Commands.RefreshToken;
using Application.Features.Identity.Commands.Register;
using Application.Features.Identity.Commands.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginCommand command)
        => Ok(await _mediator.Send(command));


    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
        => Ok(await _mediator.Send(command));


    [HttpPost("[action]")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("[action]")]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        => Ok(await _mediator.Send(command));

}
