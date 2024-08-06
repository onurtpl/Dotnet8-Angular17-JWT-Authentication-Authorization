using Domain.Entities.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Surname).IsRequired().HasMaxLength(50);
        builder.Ignore(u => u.FullName); // FullName is a computed property, so we ignore it
    }
}
