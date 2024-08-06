# Angular 17 and .Net 8 Jwt Authentication Application

This is an Angular 17 standalone application that demonstrates user authentication, role-based access control, and token refresh using `CanActivateFn` for guards and `HttpInterceptorFn` for interceptors.

## Features

- User login and registration
- Auth guard for protecting routes
- Role guard for role-based access control
- Refresh token mechanism to maintain user sessions
- Standalone Angular configuration without `app.module.ts`

## Prerequisites

- Node.js (v14 or higher recommended)
- Angular CLI (v17 or higher)

## Getting Started

### Installation

1. **Clone the repository:**
   ```bash

git clone https://github.com/onurtpl/Dotnet8-Angular17-JWT-Authentication-Authorization.git
cd Dotnet8-Angular17-JWT-Authentication-Authorization


### Installation
\src/
\├── backend/ 
\|   ├── API/
\|   |   ├── Configurations/ 
|   |   |   ├── APIConfigurations.cs 
|   |   |   ├── ApplicationConfigurations.cs
|   |   |   ├── InfrastructureConfigurations.cs
|   |   |   ├── RepositoryConfigurations.cs
|   |   ├── Controllers/
|   |   |   ├── Abstractions/
|   |   |   |   ├── ApiController.cs
|   |   |   ├── AuthController.cs
|   |   |   ├── RoleController.cs
|   |   |   ├── UserController.cs
|   |   ├── Middlewares/
|   |   |   ├── ExceptionMiddleware.cs
|   |   ├── Models/
|   |   |   ├── ErrorResultModel.cs
|   |   |   ├── ErrorStatusCodeModel.cs
|   |   |   ├── ValidationErrorDetailsModel.cs
|   |   ├── Program.cs
|   |   ├── API.csproj
|   |   ├── appsettings.json
|   |   ├── appsettings.Development.json
|   ├── Application/
|   |   ├── Behaviors/
|   |   |   ├── CustomValidationBehavior.cs
|   |   ├── Contracts/
|   |   |   ├── IdentityContracts/
|   |   |   |   ├── IIdentityRepository.cs
|   |   |   ├── MailContracts/
|   |   |   |   ├── IMailRepository.cs
|   |   ├── Dtos/
|   |   |   ├── PaginationDtos/
|   |   |   |   ├── PaginationRequestDto.cs
|   |   |   |   ├── PaginationResponseDto.cs
|   |   |   ├── AuthResponseDto.cs
|   |   ├── Features/
|   |   |   ├── Application/
|   |   |   ├── Identity/
|   |   |   |   ├── Commands/
|   |   |   |   |   ├── AssignRole/
|   |   |   |   |   |   ├── AssignRoleCommand.cs
|   |   |   |   |   |   ├── AssignRoleCommandHandler.cs
|   |   |   |   |   |   ├── AssignRoleCommandValidator.cs
|   |   |   |   |   ├── CreateRole/
|   |   |   |   |   |   ├── CreateRoleCommand.cs
|   |   |   |   |   |   ├── CreateRoleCommandHandler.cs
|   |   |   |   |   |   ├── CreateRoleCommandValidator.cs
|   |   |   |   |   ├── ForgotPassword/
|   |   |   |   |   |   ├── ForgotPasswordCommand.cs
|   |   |   |   |   |   ├── ForgotPasswordCommandHandler.cs
|   |   |   |   |   |   ├── ForgotPasswordCommandValidator.cs
|   |   |   |   |   ├── GetUsers/
|   |   |   |   |   |   ├── GetUsersCommand.cs
|   |   |   |   |   |   ├── GetUsersCommandHandler.cs
|   |   |   |   |   |   ├── GetUsersCommandResult.cs
|   |   |   |   |   ├── Login/
|   |   |   |   |   |   ├── LoginCommand.cs
|   |   |   |   |   |   ├── LoginCommandHandler.cs
|   |   |   |   |   |   ├── LoginCommandValidator.cs
|   |   |   |   |   ├── RefreshToken/
|   |   |   |   |   |   ├── RefreshTokenCommand.cs
|   |   |   |   |   |   ├── RefreshTokenCommandHandler.cs
|   |   |   |   |   |   ├── RefreshTokenCommandValidator.cs
|   |   |   |   |   ├── Register/
|   |   |   |   |   |   ├── RegisterCommand.cs
|   |   |   |   |   |   ├── RegisterCommandHandler.cs
|   |   |   |   |   |   ├── RegisterCommandValidator.cs
|   |   |   |   |   ├── ResetPassword/
|   |   |   |   |   |   ├── ResetPasswordCommand.cs
|   |   |   |   |   |   ├── ResetPasswordCommandHandler.cs
|   |   |   |   |   |   ├── ResetPasswordCommandValidator.cs
|   |   |   |   ├── Queries/
|   |   |   |   |   ├── GetRoles/
|   |   |   |   |   |   ├── GetRolesQuery.cs
|   |   |   |   |   |   ├── GetRolesQueryHandler.cs
|   |   |   |   |   |   ├── GetRolesQueryResult.cs
|   |   |   ├── Application.csproj
|   |   |   ├── ApplicationAssembly.cs
|   ├── Domain/
|   |   ├── Entities/
|   |   |   ├── Abstractions/
|   |   |   |   ├── BaseEntity.cs
|   |   |   ├── Errors/
|   |   |   |   ├── ErrorLog.cs
|   |   |   ├── IdentityEntities/
|   |   |   |   ├── ApplicationRole.cs
|   |   |   |   ├── ApplicationUser.cs
|   |   ├── Domain.csproj
|   ├── Infrastructure/
|   |   ├── Configurations/
|   |   |   ├── ApplicationRoleConfiguration.cs
|   |   |   ├── ApplicationUserConfiguration.cs
|   |   |   ├── ErrorLogConfiguration.cs
|   |   ├── Context/
|   |   |   ├── ApplicationDbContext.cs
|   |   ├── Implementations/
|   |   |   ├── ApplicationImplementations/
|   |   |   ├── IdentityImplementations/
|   |   |   |   ├── IdentityRepository.cs
|   |   |   ├── MailImplementations/
|   |   |   |   ├── MailRepository.cs
|   |   ├── Initializations/
|   |   |   ├── SeedUserAndRole.cs
|   |   ├── Mapping/
|   |   |   ├── MappingProfile.cs
|   ├── Infrastructure.csproj
|   ├── backend.sln
