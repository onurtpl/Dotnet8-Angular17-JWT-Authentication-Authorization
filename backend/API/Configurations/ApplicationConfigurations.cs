using Application;
using Application.Behaviors;
using FluentValidation;
using MediatR;

namespace API.Configurations;

internal static class ApplicationConfigurations
{
    internal static void AddApplicationConfigurations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(ApplicationAssembly).Assembly);
        services.AddMediatR(
            cfr => cfr.RegisterServicesFromAssembly(
            typeof(ApplicationAssembly).Assembly));
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CustomValidationBehavior<,>));

    }
}
