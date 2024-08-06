using Application.Contracts.IdentityContracts;
using Application.Dtos;
using MediatR;

namespace Application.Features.Identity.Commands.RefreshToken;

public sealed class RefreshTokenCommandHandler :
    IRequestHandler<RefreshTokenCommand, AuthResponseDto>
{
    private readonly IIdentityRepository _repository;

    public RefreshTokenCommandHandler(IIdentityRepository repository)
        => _repository = repository;


    public async Task<AuthResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await _repository.RefreshTokenAsync(request, cancellationToken);
    }
}
