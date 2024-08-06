using FluentValidation;

namespace Application.Features.Identity.Commands.CreateRole;

public class CreateRoleCommandValidator: AbstractValidator<CreateRoleCommand>
{
	public CreateRoleCommandValidator()
	{
		RuleFor(e => e.roleName).NotEmpty().WithMessage("RoleName boş bırakılamaz!");
	}
}
