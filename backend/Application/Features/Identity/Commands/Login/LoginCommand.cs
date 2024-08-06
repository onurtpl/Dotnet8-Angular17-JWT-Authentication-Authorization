using Application.Dtos;
using MediatR;

namespace Application.Features.Identity.Commands.Login;

public sealed record LoginCommand(
    string User,
    string Password
    ) : IRequest<AuthResponseDto>;
