using AutoMapper;
using Application.Features.Identity.Commands.GetUsers;
using Application.Features.Identity.Commands.Register;
using Domain.Entities.IdentityEntities;

namespace Infrastructure.Mapping;

public class MappingProfile: Profile
{
	public MappingProfile()
	{
		CreateMap<GetUsersCommandResult, ApplicationUser>()
			.ForMember(des => des.Id, opt => opt.MapFrom(src => src.UserId))
			.ReverseMap();

		CreateMap<RegisterCommand, ApplicationUser>().ReverseMap();
	}
}
