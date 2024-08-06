using System.Text;
using API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API.Configurations;

internal static class APIConfigurations
{
    internal static void AddAPIConfigurations(this IServiceCollection services, IConfigurationManager configuration)
    {
        IConfigurationSection policySection = configuration.GetSection("Policy");
        IConfigurationSection originSection = policySection.GetSection("Origins");
        IConfigurationSection JWTSettings = configuration.GetSection("JWTSettings");
        string securityKey = JWTSettings.GetSection("securitykey").Value!;

        string policyName = policySection.GetSection("Name").Value!;
        string[] origins = originSection.Get<string[]>()!;

        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JWTSettings["ValidIssuer"],
                ValidAudience = JWTSettings["ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),
                ClockSkew = TimeSpan.Zero,
            };
        });

        services.AddCors(options => {
            options.AddPolicy(
                name: policyName,
                policy =>
                {
                    policy.WithOrigins(origins)
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                }
            );
        });

        services.AddSwaggerGen(options => {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization: Bearer Token",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "outh2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
        });

        services.AddTransient<ExceptionMiddleware>();

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        // services.AddSwaggerGen();
    }
}
