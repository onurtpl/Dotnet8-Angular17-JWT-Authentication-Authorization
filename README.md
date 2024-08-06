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

### frontend
src/ <br>
|---frontend/ <br>
|---|---src/ <br>
|---|---|---app/ <br>
|---|---|---|---common/ <br>
|---|---|---|---|---components/ <br>
|---|---|---|---|---|---footer/ <br>
|---|---|---|---|---|---|---footer.component.html <br>
|---|---|---|---|---|---|---footer.component.scss <br>
|---|---|---|---|---|---|---footer.component.ts <br>
|---|---|---|---|---|---image-hover-card/ <br>
|---|---|---|---|---|---|---image-hover-card.component.html <br>
|---|---|---|---|---|---|---image-hover-card.component.scss <br>
|---|---|---|---|---|---|---image-hover-card.component.ts <br>
|---|---|---|---|---|---navbar/ <br>
|---|---|---|---|---|---|---navbar.component.html <br>
|---|---|---|---|---|---|---navbar.component.scss <br>
|---|---|---|---|---|---|---navbar.component.ts <br>
|---|---|---|---|---|---reactive-text-input/ <br>
|---|---|---|---|---|---|---reactive-text-input.component.htm <br>l
|---|---|---|---|---|---|---reactive-text-input.component.scs <br>s
|---|---|---|---|---|---|---reactive-text-input.component.ts <br>
|---|---|---|---|---directives/ <br>
|---|---|---|---|---|---toggle-password.directive.ts <br>
|---|---|---|---|---guards/ <br>
|---|---|---|---|---|---auth.guard.ts <br>
|---|---|---|---|---|---role.guard.ts <br>
|---|---|---|---|---interceptors/ <br>
|---|---|---|---|---|---auth.interceptor.ts <br>
|---|---|---|---|---interfaces/ <br>
|---|---|---|---|---|---jwt-payload.ts <br>
|---|---|---|---|---|---pagination-request.ts <br>
|---|---|---|---|---|---pagination-response.ts <br>
|---|---|---|---|---|---user-response.ts <br>
|---|---|---|---|---modules/ <br>
|---|---|---|---|---|---app-common/ <br>
|---|---|---|---|---|---|---app-common.module.ts <br>
|---|---|---|---|---|---material-form-shared/ <br>
|---|---|---|---|---|---|---material-form-shared.module.ts <br>
|---|---|---|---|---services/ <br>
|---|---|---|---|---|---generic-http.service.ts <br>
|---|---|---|---|---|---notification.service.ts <br>
|---|---|---|---layouts/ <br>
|---|---|---|---|---admin/ <br>
|---|---|---|---|---|---pages/ <br>
|---|---|---|---|---|---|---user-detail/ <br>
|---|---|---|---|---|---|---|---user-detail.component.html <br>
|---|---|---|---|---|---|---|---user-detail.component.scss <br>
|---|---|---|---|---|---|---|---user-detail.component.ts <br>
|---|---|---|---|---|---user-list/ <br>
|---|---|---|---|---|---|---|---user-list.component.html <br>
|---|---|---|---|---|---|---|---user-list.component.scss <br>
|---|---|---|---|---|---|---|---user-list.component.ts <br>
|---|---|---|---|---|---services/ <br>
|---|---|---|---|---|---|---admin.service.ts <br>
|---|---|---|---|---|---admin.component.html <br>
|---|---|---|---|---|---admin.component.scss <br>
|---|---|---|---|---|---admin.component.ts <br>
|---|---|---|---|---|---admin.routes.ts <br>
|---|---|---|---|---auth/ <br>
|---|---|---|---|---|---interfaces/ <br>
|---|---|---|---|---|---|---auth-response.ts <br>
|---|---|---|---|---|---|---forgot-password-request.ts <br>
|---|---|---|---|---|---|---login-request.ts <br>
|---|---|---|---|---|---|---refresh-token-request.ts <br>
|---|---|---|---|---|---|---register-request.ts <br>
|---|---|---|---|---|---|---reset-password-request.ts <br>
|---|---|---|---|---|---pages/ <br>
|---|---|---|---|---|---|---forgot-password/ <br>
|---|---|---|---|---|---|---|---forgot-password.component.htm <br>l
|---|---|---|---|---|---|---|---forgot-password.component.scs <br>s
|---|---|---|---|---|---|---|---forgot-password.component.ts <br>
|---|---|---|---|---|---|---login/ <br>
|---|---|---|---|---|---|---|---login.component.html <br>
|---|---|---|---|---|---|---|---login.component.scss <br>
|---|---|---|---|---|---|---|---login.component.ts <br>
|---|---|---|---|---|---|---register/ <br>
|---|---|---|---|---|---|---|---register.component.html <br>
|---|---|---|---|---|---|---|---register.component.scss <br>
|---|---|---|---|---|---|---|---register.component.ts <br>
|---|---|---|---|---|---|---reset-password/ <br>
|---|---|---|---|---|---|---|---register.component.html <br>
|---|---|---|---|---|---|---|---register.component.scss <br>
|---|---|---|---|---|---|---|---register.component.ts <br>
|---|---|---|---|---|---services/ <br>
|---|---|---|---|---|---|---auth.service.ts <br>
|---|---|---|---|---|---auth.component.html <br>
|---|---|---|---|---|---auth.component.scss <br>
|---|---|---|---|---|---auth.component.ts <br>
|---|---|---|---|---|---auth.routes.ts <br>
|---|---|---|---|---home/ <br>
|---|---|---|---|---|---pages/ <br>
|---|---|---|---|---|---|---home-detail/ <br>
|---|---|---|---|---|---|---|---home-detail.component.html <br>
|---|---|---|---|---|---|---|---home-detail.component.scss <br>
|---|---|---|---|---|---|---home-main/ <br>
|---|---|---|---|---|---|---|---home-main.component.html <br>
|---|---|---|---|---|---|---|---home-main.component.scss <br>
|---|---|---|---|---|---|---|---home-main.component.ts <br>
|---|---|---|---|---home.component.html <br>
|---|---|---|---|---home.component.scss <br>
|---|---|---|---|---home.component.ts <br>
|---|---|---|---|---home.routes.ts <br>
|---|---|---|---not-found/ <br>
|---|---|---|---|---not-found.component.html <br>
|---|---|---|---|---not-found.component.scss <br>
|---|---|---|---app.component.html <br>
|---|---|---|---app.component.scss <br>
|---|---|---|---app.component.ts <br>
|---|---|---|---app.config.ts <br>
|---|---|---|---app.routes.ts <br>
|---|---assets/ <br>
|---|---|---images/ <br>
|---|---|---|---kodlama.png <br>
|---|---environments/ <br>
|---|---|---environment.development.ts <br>
|---|---|---environment.prod.ts <br>
|---|---|---environment.ts <br>

