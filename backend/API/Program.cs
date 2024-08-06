using API.Configurations;
using API.Middlewares;
using Domain.Entities.IdentityEntities;
using Infrastructure.Initializations;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

IConfigurationSection policySection = builder.Configuration.GetSection("Policy");
string policyName = policySection.GetSection("Name").Value!;

// Add services to the container.

builder.Services.AddInfrastructureConfigurations(builder.Configuration, builder.Host);
builder.Services.AddApplicationConfigurations();
builder.Services.AddRepositoryConfigurations();
builder.Services.AddAPIConfigurations(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors(policyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

    await SeedUserAndRole.Initialize(userManager, roleManager);
}

app.Run();
