using Application.Contracts.IdentityContracts;
using MediatR;

namespace Application.Features.Identity.Commands.AssignRole;

public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, bool>
{
    private readonly IIdentityRepository _repository;

    public AssignRoleCommandHandler(IIdentityRepository repository)
        => _repository = repository;
   

    public async Task<bool> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
    {
        return await _repository.AssignRoleAsync(request, cancellationToken);
    }
}
