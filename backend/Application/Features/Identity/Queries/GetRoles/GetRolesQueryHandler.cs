using Application.Contracts.IdentityContracts;
using MediatR;

namespace Application.Features.Identity.Queries.GetRoles;

public sealed class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IEnumerable<GetRolesQueryResult>>
{
    private readonly IIdentityRepository _repository;

    public GetRolesQueryHandler(IIdentityRepository repository)
        => _repository = repository;


    public async Task<IEnumerable<GetRolesQueryResult>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetRolesAsync(request, cancellationToken);
    }
}
