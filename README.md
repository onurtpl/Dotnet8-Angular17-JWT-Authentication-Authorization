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
src/ <br>
|___backend/ <br>
|___|__API/ <br>
|___|___|___Configurations/ <br>
|___|___|___|___APIConfigurations.cs <br>
|___|___|___|___ApplicationConfigurations.cs <br>
|___|___|___|___InfrastructureConfigurations.cs <br>
|___|___|___|___RepositoryConfigurations.cs <br>
|___|___|__─_Controllers/ <br>
|___|___|___|___Abstractions/ <br>
|___|___|___|___|___ApiController.cs <br>
|___|___|___|___AuthController.cs <br>
|___|___|___|___RoleController.cs <br>
|___|___|___|___UserController.cs <br>
|___|___|___Middlewares/ <br>
|___|___|___|___ExceptionMiddleware.cs <br>
|___|___|___Models/ <br>
|___|___|___|___ErrorResultModel.cs <br>
|___|___|___|___ErrorStatusCodeModel.cs <br>
|___|___|___|___ValidationErrorDetailsModel.cs <br>
|___|___|___Program.cs <br>
|___|___|___API.csproj <br>
|___|___|___appsettings.json <br>
|___|___|___appsettings.Development.json <br>
|___|___Application/ <br>
|___|___|___Behaviors/ <br>
|___|___|___|___CustomValidationBehavior.cs <br>
|___|___|___Contracts/ <br>
|___|___|___|___IdentityContracts/ <br>
|___|___|___|___|___IIdentityRepository.cs <br>
|___|___|___|___MailContracts/ <br>
|___|___|___|___|___IMailRepository.cs <br>
|___|___|___Dtos/ <br>
|___|___|___|___PaginationDtos/ <br>
|___|___|___|___|___PaginationRequestDto.cs <br>
|___|___|___|___|___PaginationResponseDto.cs <br>
|___|___|___|___AuthResponseDto.cs <br>
|___|___|___Features/ <br>
|___|___|___|___Application/ <br>
|___|___|___|___Identity/ <br>
|___|___|___|___|___Commands/ <br>
|___|___|___|___|___|___AssignRole/ <br>
|___|___|___|___|___|___|___AssignRoleCommand.cs <br>
|___|___|___|___|___|___|___AssignRoleCommandHandler.cs <br>
|___|___|___|___|___|___|___AssignRoleCommandValidator.cs <br>
|___|___|___|___|___|___CreateRole/ <br>
|___|___|___|___|___|___|___CreateRoleCommand.cs <br>
|___|___|___|___|___|___|___CreateRoleCommandHandler.cs <br>
|___|___|___|___|___|___|___CreateRoleCommandValidator.cs <br>
|___|___|___|___|___|___ForgotPassword/ <br>
|___|___|___|___|___|___|___ForgotPasswordCommand.cs <br>
|___|___|___|___|___|___|___ForgotPasswordCommandHandler.cs <br>
|___|___|___|___|___|___|___ForgotPasswordCommandValidator.cs <br>
|___|___|___|___|___|___GetUsers/ <br>
|___|___|___|___|___|___|___GetUsersCommand.cs <br>
|___|___|___|___|___|___|___GetUsersCommandHandler.cs <br>
|___|___|___|___|___|___|___GetUsersCommandResult.cs <br>
|___|___|___|___|___|___Login/ <br>
|___|___|___|___|___|___|___LoginCommand.cs <br>
|___|___|___|___|___|___|___LoginCommandHandler.cs <br>
|___|___|___|___|___|___|___LoginCommandValidator.cs <br>
|___|___|___|___|___|___RefreshToken/ <br>
|___|___|___|___|___|___|___RefreshTokenCommand.cs <br>
|___|___|___|___|___|___|___RefreshTokenCommandHandler.cs <br>
|___|___|___|___|___|___|___RefreshTokenCommandValidator.cs <br>
|___|___|___|___|___|___Register/ <br>
|___|___|___|___|___|___|___RegisterCommand.cs <br>
|___|___|___|___|___|___|___RegisterCommandHandler.cs <br>
|___|___|___|___|___|___|___RegisterCommandValidator.cs <br>
|___|___|___|___|___|___ResetPassword/ <br>
|___|___|___|___|___|___|___ResetPasswordCommand.cs <br>
|___|___|___|___|___|___|___ResetPasswordCommandHandler.cs <br>
|___|___|___|___|___|___|___ResetPasswordCommandValidator.cs <br>
|___|___|___|___|___Queries/ <br>
|___|___|___|___|___|___GetRoles/ <br>
|___|___|___|___|___|___|___GetRolesQuery.cs <br>
|___|___|___|___|___|___|___GetRolesQueryHandler.cs <br>
|___|___|___|___|___|___|___GetRolesQueryResult.cs <br>
|___|___|___|___Application.csproj <br>
|___|___|___|___ApplicationAssembly.cs <br>
|___|___Domain/ <br>
|___|___|___Entities/ <br>
|___|___|___|___Abstractions/ <br>
|___|___|___|___|___BaseEntity.cs <br>
|___|___|___|___Errors/ <br>
|___|___|___|___|___ErrorLog.cs <br>
|___|___|___|___IdentityEntities/ <br>
|___|___|___|___|___ApplicationRole.cs <br>
|___|___|___|___|___ApplicationUser.cs <br>
|___|___|___Domain.csproj <br>
|___|___Infrastructure/ <br>
|___|___|___Configurations/ <br>
|___|___|___|___ApplicationRoleConfiguration.cs <br>
|___|___|___|___ApplicationUserConfiguration.cs <br>
|___|___|___|___ErrorLogConfiguration.cs <br>
|___|___|___Context/ <br>
|___|___|___|___ApplicationDbContext.cs <br>
|___|___|___Implementations/ <br>
|___|___|___|___ApplicationImplementations/ <br>
|___|___|___|___IdentityImplementations/ <br>
|___|___|___|___|___IdentityRepository.cs <br>
|___|___|___|___MailImplementations/ <br>
|___|___|___|___|___MailRepository.cs <br>
|___|___|___Initializations/ <br>
|___|___|___|___SeedUserAndRole.cs <br>
|___|___|___Mapping/ <br>
|___|___|___|___MappingProfile.cs <br>
|___|___Infrastructure.csproj <br>
|___|___backend.sln <br>

