# Agent Guide for DotnetApi

## Project overview
This repository is an ASP.NET Core Web API project targeting .NET 10. The app uses:

- ASP.NET Core Web API
- Entity Framework Core with PostgreSQL
- JWT authentication and authorization
- Swagger/OpenAPI for local API exploration
- Repository/service layering with dependency injection

## Important project files
- `Program.cs` – app startup, DI registration, JWT setup, Swagger setup, middleware registration
- `DotnetApi.csproj` – project dependencies and target framework
- `Data/AppDbContext.cs` – EF Core database context
- `Controllers/` – API endpoints
- `Services/` – business logic
- `Repositories/` – data access abstractions and implementations
- `Entities/` – domain models
- `Dtos/` – request/response DTOs
- `Extensions/` – app startup helpers and exception/auth configuration
- `Middleware/` – custom middleware like `ExceptionMiddleware`
- `configuration/JwtSettings.cs` – JWT configuration model
- `appsettings.json` and `appsettings.Development.json` – configuration

## Local run commands
From the repository root:

```bash
dotnet restore
dotnet build
dotnet run
```

For live development:

```bash
dotnet watch run
```

## Database and migrations
This project uses EF Core with PostgreSQL. Typical commands:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
dotnet ef migrations list
```

If the database connection string is missing or invalid, check:

- `appsettings.json`
- `appsettings.Development.json`
- `Data/AppDbContext.cs`

## Authentication and authorization
Authentication is configured in `Program.cs` and uses JWT bearer tokens.

Key points:
- JWT settings are loaded from `JwtSettings`
- `AddAuthentication(...)` and `AddAuthorization()` are enabled
- Swagger includes a bearer token security definition
- Controllers likely use `[Authorize]` or role-based authorization depending on the endpoint

## Architecture conventions
Follow the established patterns already in the project:

- Keep controllers thin; delegate business logic to services
- Use interfaces for services/repositories and register them in DI
- Keep DTOs separate from entity models
- Put validation or business rules in service classes, not controllers
- Prefer the existing project naming style and layering unless a broader refactor is explicitly requested

## Dependency injection
Service registration is centralized through extension methods, especially in the `Extensions/` folder and startup code in `Program.cs`.

When adding a new service:
1. Create an interface in the relevant `Interfaces/` or `Services/` area if the pattern matches
2. Add the implementation class
3. Register it in the appropriate extension method or `Program.cs`
4. Inject it into the controller or service that needs it

## Error handling
The app uses a custom exception middleware for global exception handling.

When adding new behavior:
- Prefer throwing a domain-specific exception or a custom `AppException`
- Keep the middleware responsible for consistent API error responses
- Avoid swallowing exceptions in controllers unless the behavior is intentionally handled

## Code change guidance for agents
- Do not rewrite the app structure unless asked
- Keep changes minimal and consistent with surrounding code
- Preserve current naming conventions and project layering
- Prefer editing existing files over introducing new patterns
- If a change affects auth, DTOs, EF Core models, or database schema, verify the impact on both runtime and migrations

## Quick repo sanity checklist
Before finishing a task, verify:

- Build passes: `dotnet build`
- App still starts: `dotnet run`
- Database migrations still make sense if schema changed
- JWT/auth flows still align with configured settings
- Swagger remains usable for the API surface you changed

## Notes
This repo appears to have some legacy naming inconsistencies and a few incomplete/older files, so maintain compatibility with the existing patterns rather than normalizing everything blindly.
