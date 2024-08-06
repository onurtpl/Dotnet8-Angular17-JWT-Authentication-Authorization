using Application.Contracts.IdentityContracts;
using MediatR;

namespace Application.Features.Identity.Commands.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
{
    private readonly IIdentityRepository _repository;

    public ResetPasswordCommandHandler(IIdentityRepository repository)
        => _repository = repository;
    

    public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        return await _repository.ResetPassword(request, cancellationToken);
    }
}
