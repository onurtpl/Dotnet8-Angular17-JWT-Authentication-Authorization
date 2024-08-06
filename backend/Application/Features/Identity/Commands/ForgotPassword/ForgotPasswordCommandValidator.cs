using FluentValidation;

namespace Application.Features.Identity.Commands.ForgotPassword;

public class ForgotPasswordCommandValidator: AbstractValidator<ForgotPasswordCommand>
{
	public ForgotPasswordCommandValidator()
	{
		RuleFor(e => e.Email)
			.NotEmpty().WithMessage("Mail Alanı boş bırakılamaz!");
	}
}
