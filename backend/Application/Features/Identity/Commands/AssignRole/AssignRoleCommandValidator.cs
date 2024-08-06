using FluentValidation;

namespace Application.Features.Identity.Commands.AssignRole;

public class AssignRoleCommandValidator: AbstractValidator<AssignRoleCommand>
{
	public AssignRoleCommandValidator()
	{
		RuleFor(e => e.Role)
			.NotEmpty().WithMessage("Role adı boş bırakılamaz!");
        RuleFor(e => e.User)
            .NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz!");
    }
}
