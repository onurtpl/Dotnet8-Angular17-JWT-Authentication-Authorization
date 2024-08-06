using MediatR;

namespace Application.Features.Identity.Commands.ForgotPassword;

public sealed record ForgotPasswordCommand: IRequest<bool>
{
    public required string Email { get; set; } = string.Empty;
}
