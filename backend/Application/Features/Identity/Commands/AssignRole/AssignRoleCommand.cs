using MediatR;

namespace Application.Features.Identity.Commands.AssignRole;

public sealed record AssignRoleCommand: IRequest<bool>
{
    public required string User { get; set; } = string.Empty;
    public required string Role { get; set; } = string.Empty;
}
