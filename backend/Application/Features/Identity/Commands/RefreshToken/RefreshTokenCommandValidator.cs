using FluentValidation;

namespace Application.Features.Identity.Commands.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(e => e.RefreshToken)
            .NotEmpty().WithMessage("Refresh token bulunamadı!");
        RuleFor(e => e.User)
            .NotEmpty().WithMessage("User alanı zorunludur!");
    }
}
