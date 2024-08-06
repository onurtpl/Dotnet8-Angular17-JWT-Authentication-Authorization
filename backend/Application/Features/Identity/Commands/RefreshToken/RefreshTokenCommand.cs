using Application.Dtos;
using MediatR;

namespace Application.Features.Identity.Commands.RefreshToken;

public sealed record RefreshTokenCommand(
    string User,
    string RefreshToken
    ) : IRequest<AuthResponseDto>;
