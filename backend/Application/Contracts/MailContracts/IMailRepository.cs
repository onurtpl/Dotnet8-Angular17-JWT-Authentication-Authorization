using Application.Features.Identity.Commands.ForgotPassword;

namespace Application.Contracts.MailContracts;

public interface IMailRepository
{
    Task<bool> ForgotPasswordViaSMTP(ForgotPasswordCommand request, CancellationToken cancellationToken);
}

