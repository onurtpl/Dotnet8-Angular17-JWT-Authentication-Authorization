using Application.Dtos.PaginationDtos;
using MediatR;

namespace Application.Features.Identity.Commands.GetUsers;

public sealed record GetUsersCommand : PaginationRequestDto,
    IRequest<PaginationResponseDto<GetUsersCommandResult>>;

public sealed record GetUsersCommandResult
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? SurName { get; set; }
    public string[]? Roles { get; set; }
}
