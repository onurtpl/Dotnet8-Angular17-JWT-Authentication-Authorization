using Application.Contracts.IdentityContracts;
using Application.Dtos;
using MediatR;

namespace Application.Features.Identity.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly IIdentityRepository _repository;

    public LoginCommandHandler(IIdentityRepository repository)
        => _repository = repository;


    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _repository.LoginAsync(request, cancellationToken);
    }
}
