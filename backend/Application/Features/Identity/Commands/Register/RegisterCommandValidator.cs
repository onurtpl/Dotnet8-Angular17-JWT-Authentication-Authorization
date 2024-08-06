using FluentValidation;

namespace Application.Features.Identity.Commands.Register;
public class RegisterCommandValidator :
    AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name alanı boş bırakılamaz!");

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email alanı boş bırakılamaz!")
            .EmailAddress().WithMessage("Lütfen kullanılabilir bir email giriniz!");

        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password alanı boş bırakılamaz!")
            .MinimumLength(6).WithMessage("Password alanı en az 6 karakterden oluşmalıdır!");

        RuleFor(e => e.UserName)
            .NotEmpty().WithMessage("Username alanı boş bırakılamaz!")
            .MinimumLength(3).WithMessage("Username alanı en az 3 karakterden oluşmalıdır!");
    }
}
