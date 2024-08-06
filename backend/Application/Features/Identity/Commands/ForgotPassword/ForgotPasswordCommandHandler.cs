using Application.Contracts.MailContracts;
using MediatR;

namespace Application.Features.Identity.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, bool>
{
    private readonly IMailRepository _repository;

    public ForgotPasswordCommandHandler(IMailRepository repository)
        => _repository = repository;
   

    public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        return await _repository.ForgotPasswordViaSMTP(request, cancellationToken);
    }
}
