using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.IdentityEntities;
public sealed class ApplicationUser: IdentityUser
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? FullName => $"{Name} {Surname}";

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireTime { get; set; }
}
