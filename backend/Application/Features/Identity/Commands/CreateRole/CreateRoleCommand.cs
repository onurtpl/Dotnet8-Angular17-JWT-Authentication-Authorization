using MediatR;

namespace Application.Features.Identity.Commands.CreateRole;

public sealed record CreateRoleCommand(string roleName): IRequest<bool>;
