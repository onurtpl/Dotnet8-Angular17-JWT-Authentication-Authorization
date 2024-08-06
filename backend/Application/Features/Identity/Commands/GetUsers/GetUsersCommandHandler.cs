using Application.Contracts.IdentityContracts;
using Application.Dtos.PaginationDtos;
using MediatR;

namespace Application.Features.Identity.Commands.GetUsers;

public class GetUsersCommandHandler :
    IRequestHandler<GetUsersCommand,
        PaginationResponseDto<GetUsersCommandResult>>
{
    private readonly IIdentityRepository _repository;

    public GetUsersCommandHandler(IIdentityRepository repository)
        => _repository = repository;
    public async Task<PaginationResponseDto<GetUsersCommandResult>> Handle(
        GetUsersCommand request, CancellationToken cancellationToken)
    {
        return await _repository.GetUsersAsync(request, cancellationToken);
    }
}
