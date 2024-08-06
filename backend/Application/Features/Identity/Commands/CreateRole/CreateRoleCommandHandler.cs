using Application.Contracts.IdentityContracts;
using MediatR;

namespace Application.Features.Identity.Commands.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, bool>
{
    private readonly IIdentityRepository _repository;

    public CreateRoleCommandHandler(IIdentityRepository repository)
        => _repository = repository;
    

    public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateRoleAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
