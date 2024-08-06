using Application.Dtos;
using Application.Dtos.PaginationDtos;
using Application.Features.Identity.Commands.AssignRole;
using Application.Features.Identity.Commands.CreateRole;
using Application.Features.Identity.Commands.GetUsers;
using Application.Features.Identity.Commands.Login;
using Application.Features.Identity.Commands.RefreshToken;
using Application.Features.Identity.Commands.Register;
using Application.Features.Identity.Commands.ResetPassword;
using Application.Features.Identity.Queries.GetRoles;

namespace Application.Contracts.IdentityContracts;

public interface IIdentityRepository
{
    Task<AuthResponseDto> LoginAsync(LoginCommand request, CancellationToken token);
    Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenCommand request, CancellationToken token);
    Task<bool> RegisterAsync(RegisterCommand request, CancellationToken cancellationToken);
    Task<bool> AssignRoleAsync(AssignRoleCommand request, CancellationToken token);
    Task<PaginationResponseDto<GetUsersCommandResult>> GetUsersAsync(GetUsersCommand request, CancellationToken cancellationToken);
    Task<IEnumerable<GetRolesQueryResult>> GetRolesAsync(GetRolesQuery request, CancellationToken cancellationToken);
    public Task<bool> CreateRoleAsync(CreateRoleCommand request, CancellationToken cancellationToken);
    public Task<bool> ResetPassword(ResetPasswordCommand request, CancellationToken cancellationToken);

}

