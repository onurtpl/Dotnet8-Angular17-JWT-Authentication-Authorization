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


## Project Structure
### Backend
|---backend/ <br>
|---|--API/ <br>
|---|---|---Configurations/ <br>
|---|---|---|---APIConfigurations.cs <br>
|---|---|---|---ApplicationConfigurations.cs <br>
|---|---|---|---InfrastructureConfigurations.cs <br>
|---|---|---|---RepositoryConfigurations.cs <br>
|---|---|--─-Controllers/ <br>
|---|---|---|---Abstractions/ <br>
|---|---|---|---|---ApiController.cs <br>
|---|---|---|---AuthController.cs <br>
|---|---|---|---RoleController.cs <br>
|---|---|---|---UserController.cs <br>
|---|---|---Middlewares/ <br>
|---|---|---|---ExceptionMiddleware.cs <br>
|---|---|---Models/ <br>
|---|---|---|---ErrorResultModel.cs <br>
|---|---|---|---ErrorStatusCodeModel.cs <br>
|---|---|---|---ValidationErrorDetailsModel.cs <br>
|---|---|---Program.cs <br>
|---|---|---API.csproj <br>
|---|---|---appsettings.json <br>
|---|---|---appsettings.Development.json <br>
|---|---Application/ <br>
|---|---|---Behaviors/ <br>
|---|---|---|---CustomValidationBehavior.cs <br>
|---|---|---Contracts/ <br>
|---|---|---|---IdentityContracts/ <br>
|---|---|---|---|---IIdentityRepository.cs <br>
|---|---|---|---MailContracts/ <br>
|---|---|---|---|---IMailRepository.cs <br>
|---|---|---Dtos/ <br>
|---|---|---|---PaginationDtos/ <br>
|---|---|---|---|---PaginationRequestDto.cs <br>
|---|---|---|---|---PaginationResponseDto.cs <br>
|---|---|---|---AuthResponseDto.cs <br>
|---|---|---Features/ <br>
|---|---|---|---Application/ <br>
|---|---|---|---Identity/ <br>
|---|---|---|---|---Commands/ <br>
|---|---|---|---|---|---AssignRole/ <br>
|---|---|---|---|---|---|---AssignRoleCommand.cs <br>
|---|---|---|---|---|---|---AssignRoleCommandHandler.cs <br>
|---|---|---|---|---|---|---AssignRoleCommandValidator.cs <br>
|---|---|---|---|---|---CreateRole/ <br>
|---|---|---|---|---|---|---CreateRoleCommand.cs <br>
|---|---|---|---|---|---|---CreateRoleCommandHandler.cs <br>
|---|---|---|---|---|---|---CreateRoleCommandValidator.cs <br>
|---|---|---|---|---|---ForgotPassword/ <br>
|---|---|---|---|---|---|---ForgotPasswordCommand.cs <br>
|---|---|---|---|---|---|---ForgotPasswordCommandHandler.cs <br>
|---|---|---|---|---|---|---ForgotPasswordCommandValidator.cs <br>
|---|---|---|---|---|---GetUsers/ <br>
|---|---|---|---|---|---|---GetUsersCommand.cs <br>
|---|---|---|---|---|---|---GetUsersCommandHandler.cs <br>
|---|---|---|---|---|---|---GetUsersCommandResult.cs <br>
|---|---|---|---|---|---Login/ <br>
|---|---|---|---|---|---|---LoginCommand.cs <br>
|---|---|---|---|---|---|---LoginCommandHandler.cs <br>
|---|---|---|---|---|---|---LoginCommandValidator.cs <br>
|---|---|---|---|---|---RefreshToken/ <br>
|---|---|---|---|---|---|---RefreshTokenCommand.cs <br>
|---|---|---|---|---|---|---RefreshTokenCommandHandler.cs <br>
|---|---|---|---|---|---|---RefreshTokenCommandValidator.cs <br>
|---|---|---|---|---|---Register/ <br>
|---|---|---|---|---|---|---RegisterCommand.cs <br>
|---|---|---|---|---|---|---RegisterCommandHandler.cs <br>
|---|---|---|---|---|---|---RegisterCommandValidator.cs <br>
|---|---|---|---|---|---ResetPassword/ <br>
|---|---|---|---|---|---|---ResetPasswordCommand.cs <br>
|---|---|---|---|---|---|---ResetPasswordCommandHandler.cs <br>
|---|---|---|---|---|---|---ResetPasswordCommandValidator.cs <br>
|---|---|---|---|---Queries/ <br>
|---|---|---|---|---|---GetRoles/ <br>
|---|---|---|---|---|---|---GetRolesQuery.cs <br>
|---|---|---|---|---|---|---GetRolesQueryHandler.cs <br>
|---|---|---|---|---|---|---GetRolesQueryResult.cs <br>
|---|---|---|---Application.csproj <br>
|---|---|---|---ApplicationAssembly.cs <br>
|---|---Domain/ <br>
|---|---|---Entities/ <br>
|---|---|---|---Abstractions/ <br>
|---|---|---|---|---BaseEntity.cs <br>
|---|---|---|---Errors/ <br>
|---|---|---|---|---ErrorLog.cs <br>
|---|---|---|---IdentityEntities/ <br>
|---|---|---|---|---ApplicationRole.cs <br>
|---|---|---|---|---ApplicationUser.cs <br>
|---|---|---Domain.csproj <br>
|---|---Infrastructure/ <br>
|---|---|---Configurations/ <br>
|---|---|---|---ApplicationRoleConfiguration.cs <br>
|---|---|---|---ApplicationUserConfiguration.cs <br>
|---|---|---|---ErrorLogConfiguration.cs <br>
|---|---|---Context/ <br>
|---|---|---|---ApplicationDbContext.cs <br>
|---|---|---Implementations/ <br>
|---|---|---|---ApplicationImplementations/ <br>
|---|---|---|---IdentityImplementations/ <br>
|---|---|---|---|---IdentityRepository.cs <br>
|---|---|---|---MailImplementations/ <br>
|---|---|---|---|---MailRepository.cs <br>
|---|---|---Initializations/ <br>
|---|---|---|---SeedUserAndRole.cs <br>
|---|---|---Mapping/ <br>
|---|---|---|---MappingProfile.cs <br>
|---|---Infrastructure.csproj <br>
|---|---backend.sln <br>



