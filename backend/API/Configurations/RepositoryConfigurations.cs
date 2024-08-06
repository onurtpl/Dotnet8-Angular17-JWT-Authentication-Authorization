using Application.Contracts.IdentityContracts;
using Application.Contracts.MailContracts;
using Infrastructure.Implementations.IdentityImplementations;
using Infrastructure.Implementations.MailImplementations;

namespace API.Configurations;

internal static class RepositoryConfigurations
{
    internal static void AddRepositoryConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IIdentityRepository, IdentityRepository>();
        services.AddScoped<IMailRepository, MailRepository>();
    }
}
