using MediatR;

namespace Application.Features.Identity.Commands.Register;
public sealed record RegisterCommand(
    string? UserName,
    string? Name,
    string? SurName,
    string? PhoneNumber,
    string? Email,
    string? Password
    ) : IRequest<bool>;
