using FluentValidation;

namespace Application.Features.Identity.Commands.ResetPassword;

public class ResetPasswordCommandValidator: AbstractValidator<ResetPasswordCommand>
{
	public ResetPasswordCommandValidator()
	{
		RuleFor(e => e.NewPassword)
			.NotEmpty().WithMessage("NewPassword alanı boş bırakılamaz!")
			.MinimumLength(6).WithMessage("NewPassword alanı en az 6 karakterden oluşmalıdır!");

		RuleFor(e => e.Email)
			.NotEmpty().WithMessage("Email alanı boş bırakılamaz!")
			.EmailAddress().WithMessage("Email alanı doğru formatta giriniz!");

		RuleFor(e => e.Token)
			.NotEmpty().WithMessage("Invalid cookie");

    }
}
