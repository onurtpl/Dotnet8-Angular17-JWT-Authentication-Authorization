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

### Project Structure

|
├── backend
|   ├── API
|   |   ├── Configurations
|   |   |   ├── APIConfigurations.cs
|   |   |   ├── ApplicationConfigurations.cs
|   |   |   ├── InfrastructureConfigurations.cs
|   |   |   ├── RepositoryConfigurations.cs
|   |   ├── Controllers
|   |   |   ├── Abstractions
|   |   |   |   ├── ApiController.cs
|   |   |   ├── AuthController.cs
|   |   |   ├── RoleController.cs
|   |   |   ├── UserController.cs
|   |   ├── Middlewares
|   |   |   ├── ExceptionMiddleware.cs
|   |   ├── Models
|   |   |   ├── ErrorResultModel.cs
|   |   |   ├── ErrorStatusCodeModel.cs
|   |   |   ├── ValidationErrorDetailsModel.cs
|   |   ├── Program.cs
|   |   ├── API.csproj
|   |   ├── appsettings.json
|   |   ├── appsettings.Development.json
|   ├── Application
|   |   ├── Behaviors
|   |   |   ├── CustomValidationBehavior.cs
|   |   ├── Contracts
|   |   |   ├── IdentityContracts
|   |   |   |   ├── IIdentityRepository.cs
|   |   |   ├── MailContracts
|   |   |   |   ├── IMailRepository.cs
|   |   ├── Dtos
|   |   |   ├── PaginationDtos
|   |   |   |   ├── PaginationRequestDto.cs
|   |   |   |   ├── PaginationResponseDto.cs
|   |   |   ├── AuthResponseDto.cs
|   |   ├── Features
|   |   |   ├── Application
|   |   |   |   | ...
|   |   |   ├── Identity
|   |   |   |   ├── Commands
|   |   |   |   |   ├── AssignRole
|   |   |   |   |   |   ├── AssignRoleCommand.cs
|   |   |   |   |   |   ├── AssignRoleCommandHandler.cs
|   |   |   |   |   |   ├── AssignRoleCommandValidator.cs
|   |   |   |   |   ├── CreateRole
|   |   |   |   |   |   ├── CreateRoleCommand.cs
|   |   |   |   |   |   ├── CreateRoleCommandHandler.cs
|   |   |   |   |   |   ├── CreateRoleCommandValidator.cs
|   |   |   |   |   ├── ForgotPassword
|   |   |   |   |   |   ├── ForgotPasswordCommand.cs
|   |   |   |   |   |   ├── ForgotPasswordCommandHandler.cs
|   |   |   |   |   |   ├── ForgotPasswordCommandValidator.cs
|   |   |   |   |   ├── GetUsers
|   |   |   |   |   |   ├── GetUsersCommand.cs
|   |   |   |   |   |   ├── GetUsersCommandHandler.cs
|   |   |   |   |   |   ├── GetUsersCommandResult.cs
|   |   |   |   |   ├── Login
|   |   |   |   |   |   ├── LoginCommand.cs
|   |   |   |   |   |   ├── LoginCommandHandler.cs
|   |   |   |   |   |   ├── LoginCommandValidator.cs
|   |   |   |   |   ├── RefreshToken
|   |   |   |   |   |   ├── RefreshTokenCommand.cs
|   |   |   |   |   |   ├── RefreshTokenCommandHandler.cs
|   |   |   |   |   |   ├── RefreshTokenCommandValidator.cs
|   |   |   |   |   ├── Register
|   |   |   |   |   |   ├── RegisterCommand.cs
|   |   |   |   |   |   ├── RegisterCommandHandler.cs
|   |   |   |   |   |   ├── RegisterCommandValidator.cs
|   |   |   |   |   ├── ResetPassword
|   |   |   |   |   |   ├── ResetPasswordCommand.cs
|   |   |   |   |   |   ├── ResetPasswordCommandHandler.cs
|   |   |   |   |   |   ├── ResetPasswordCommandValidator.cs
|   |   |   |   ├── Queries
|   |   |   |   |   ├── GetRoles
|   |   |   |   |   |   ├── GetRolesQuery.cs
|   |   |   |   |   |   ├── GetRolesQueryHandler.cs
|   |   |   |   |   |   ├── GetRolesQueryResult.cs
|   |   |   ├── Application.csproj
|   |   |   ├── ApplicationAssembly.cs
|   ├── Domain
|   |   ├── Entities
|   |   |   ├── Abstractions
|   |   |   |   ├── BaseEntity.cs
|   |   |   ├── Errors
|   |   |   |   ├── ErrorLog.cs
|   |   |   ├── IdentityEntities
|   |   |   |   ├── ApplicationRole.cs
|   |   |   |   ├── ApplicationUser.cs
|   |   ├── Domain.csproj
|   ├── Infrastructure
|   |   ├── Configurations
|   |   |   ├── ApplicationRoleConfiguration.cs
|   |   |   ├── ApplicationUserConfiguration.cs
|   |   |   ├── ErrorLogConfiguration.cs
|   |   ├── Context
|   |   |   ├── ApplicationDbContext.cs
|   |   ├── Implementations
|   |   |   ├── ApplicationImplementations
|   |   |   |   ├── ...
|   |   |   ├── IdentityImplementations
|   |   |   |   ├── IdentityRepository.cs
|   |   |   ├── MailImplementations
|   |   |   |   ├── MailRepository.cs
|   |   ├── Initializations
|   |   |   ├── SeedUserAndRole.cs
|   |   ├── Mapping
|   |   |   ├── MappingProfile.cs
|   |   ├── Infrastructure.csproj
|   ├── backend.sln
|
├── frontend
|   ├── src
|   |   ├── app
|   |   |   ├── common
|   |   |   |   ├── components
|   |   |   |   |   ├── footer
|   |   |   |   |   |   ├── footer.component.html
|   |   |   |   |   |   ├── footer.component.scss
|   |   |   |   |   |   ├── footer.component.ts
|   |   |   |   |   ├── image-hover-card
|   |   |   |   |   |   ├── image-hover-card.component.html
|   |   |   |   |   |   ├── image-hover-card.component.scss
|   |   |   |   |   |   ├── image-hover-card.component.ts
|   |   |   |   |   ├── navbar
|   |   |   |   |   |   ├── navbar.component.html
|   |   |   |   |   |   ├── navbar.component.scss
|   |   |   |   |   |   ├── navbar.component.ts
|   |   |   |   |   ├── reactive-text-input
|   |   |   |   |   |   ├── reactive-text-input.component.html
|   |   |   |   |   |   ├── reactive-text-input.component.scss
|   |   |   |   |   |   ├── reactive-text-input.component.ts
|   |   |   |   ├── directives
|   |   |   |   |   ├── toggle-password.directive.ts
|   |   |   |   ├── gurads
|   |   |   |   |   ├── auth.guard.ts
|   |   |   |   |   ├── role.guard.ts
|   |   |   |   ├── interceptors
|   |   |   |   |   ├── auth.interceptor.ts
|   |   |   |   ├── interfaces
|   |   |   |   |   ├── jwt-payload.ts
|   |   |   |   |   ├── pagination-request.ts
|   |   |   |   |   ├── pagination-response.ts
|   |   |   |   |   ├── user-response.ts
|   |   |   |   ├── modules
|   |   |   |   |   ├── app-common
|   |   |   |   |   |   ├── app-common.module.ts
|   |   |   |   |   ├── material-form-shared
|   |   |   |   |   |   ├── material-form-shared.module.ts
|   |   |   |   ├── services
|   |   |   |   |   ├── generic-http.service.ts
|   |   |   |   |   ├── notification.service.ts
|   |   |   ├── layouts
|   |   |   |   ├── admin
|   |   |   |   |   ├── pages
|   |   |   |   |   |   ├── user-detail
|   |   |   |   |   |   |   ├── user-detail.component.html
|   |   |   |   |   |   |   ├── user-detail.component.scss
|   |   |   |   |   |   |   ├── user-detail.component.ts
|   |   |   |   |   |   ├── user-list
|   |   |   |   |   |   |   ├── user-list.component.html
|   |   |   |   |   |   |   ├── user-list.component.scss
|   |   |   |   |   |   |   ├── user-list.component.ts
|   |   |   |   |   ├── services
|   |   |   |   |   |   ├── admin.service.ts
|   |   |   |   |   ├── admin.component.html
|   |   |   |   |   ├── admin.component.scss
|   |   |   |   |   ├── admin.component.ts
|   |   |   |   |   ├── admin.routes.ts
|   |   |   |   ├── auth
|   |   |   |   |   ├── interfaces
|   |   |   |   |   |   ├── auth-response.ts
|   |   |   |   |   |   ├── forgot-password-request.ts
|   |   |   |   |   |   ├── login-request.ts
|   |   |   |   |   |   ├── refresh-token-request.ts
|   |   |   |   |   |   ├── register-request.ts
|   |   |   |   |   |   ├── reset-password-request.ts
|   |   |   |   |   ├── pages
|   |   |   |   |   |   ├── forgot-password
|   |   |   |   |   |   |   ├── forgot-password.component.html
|   |   |   |   |   |   |   ├── forgot-password.component.scss
|   |   |   |   |   |   |   ├── forgot-password.component.ts
|   |   |   |   |   |   ├── login
|   |   |   |   |   |   |   ├── login.component.html
|   |   |   |   |   |   |   ├── login.component.scss
|   |   |   |   |   |   |   ├── login.component.ts
|   |   |   |   |   |   ├── register
|   |   |   |   |   |   |   ├── register.component.html
|   |   |   |   |   |   |   ├── register.component.scss
|   |   |   |   |   |   |   ├── register.component.ts
|   |   |   |   |   |   ├── reset-password
|   |   |   |   |   |   |   ├── register.component.html
|   |   |   |   |   |   |   ├── register.component.scss
|   |   |   |   |   |   |   ├── register.component.ts
|   |   |   |   |   ├── services
|   |   |   |   |   |   ├── auth.service.ts
|   |   |   |   |   ├── auth.component.html
|   |   |   |   |   ├── auth.component.scss
|   |   |   |   |   ├── auth.component.ts
|   |   |   |   |   ├── auth.routes.ts
|   |   |   |   ├── home
|   |   |   |   |   ├── pages
|   |   |   |   |   |   ├── home-detail
|   |   |   |   |   |   |   ├── home-detail.component.html
|   |   |   |   |   |   |   ├── home-detail.component.scss
|   |   |   |   |   |   |   ├── home-detail.component.ts
|   |   |   |   |   |   ├── home-main
|   |   |   |   |   |   |   ├── home-main.component.html
|   |   |   |   |   |   |   ├── home-main.component.scss
|   |   |   |   |   |   |   ├── home-main.component.ts
|   |   |   |   |   ├── home.component.html
|   |   |   |   |   ├── home.component.scss
|   |   |   |   |   ├── home.component.ts
|   |   |   |   |   ├── home.routes.ts
|   |   |   |   ├── not-found
|   |   |   |   |   ├── not-found.component.html
|   |   |   |   |   ├── not-found.component.scss
|   |   |   |   ├── app.component.html
|   |   |   |   ├── app.component.scss
|   |   |   |   ├── app.component.ts
|   |   |   |   ├── app.config.ts
|   |   |   |   ├── app.routes.ts
|   |   ├── assets
|   |   |   ├── images
|   |   |   |   ├── kodlama.png
|   |   ├── environments
|   |   |   ├── environment.development.ts
|   |   |   ├── environment.prod.ts
|   |   |   ├── environment.ts

