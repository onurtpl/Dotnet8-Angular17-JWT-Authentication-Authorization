using Application.Contracts.IdentityContracts;
using MediatR;

namespace Application.Features.Identity.Commands.Register;
public sealed class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, bool>
{
    private readonly IIdentityRepository _repository;

    public RegisterCommandHandler(IIdentityRepository repository)
        => _repository = repository;


    public async Task<bool> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.RegisterAsync(request, cancellationToken);
    }
}
