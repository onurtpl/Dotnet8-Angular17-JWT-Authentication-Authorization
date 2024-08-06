using FluentValidation;

namespace Application.Features.Identity.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(e => e.User)
            .NotEmpty().WithMessage("Lütfen kullanıcı adı ya da şifre girin");

        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Şifre boş bırakılamaz!")
            .MinimumLength(6).WithMessage("Şifre için en az 6 karater gereklidir");
    }
}
