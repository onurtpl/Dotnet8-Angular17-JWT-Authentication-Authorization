using MediatR;

namespace Application.Features.Identity.Queries.GetRoles;

public sealed record GetRolesQuery() : IRequest<IEnumerable<GetRolesQueryResult>>;

