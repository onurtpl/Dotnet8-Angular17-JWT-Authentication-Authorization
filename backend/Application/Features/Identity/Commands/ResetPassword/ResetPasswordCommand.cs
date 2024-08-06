using MediatR;

namespace Application.Features.Identity.Commands.ResetPassword;

public sealed record ResetPasswordCommand: IRequest<bool>
{
    public required string Email { get; set; } = string.Empty;
    public required string NewPassword { get; set; } = string.Empty;
    public required string Token { get; set; } = string.Empty;

}
