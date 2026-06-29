# ProjectTrackerApi

## Stack

- .NET 10.0 ASP.NET Core Web API (`ImplicitUsings` + `Nullable` enabled)
- PostgreSQL + Entity Framework Core (Npgsql)
- JWT Bearer authentication
- Single project file (`ProjectTrackerApi.csproj`), no `.sln`

## Architecture

```
Models → DTOs → EF Repositories → Mappings (static classes) → Services → Controllers → Program.cs
```

- **Mappings** are hand-written static extension methods (no AutoMapper)
- **Repositories** (EF Core) use `DateTime.Now` (local) for `CreatedAt`
- **Services** add validation + business logic + user ownership checks
- **Controllers** use `[ApiController]` + `ControllerBase` with `[Authorize]`
- **Auth** uses BCrypt for password hashing + JWT tokens (8h expiry)

## Database

- PostgreSQL via Npgsql EF Core provider
- Connection string: `ConnectionStrings:AppContext` in `appsettings.json`
- Schema auto-created on dev startup via `EnsureCreated()`
- Entities: `User`, `Project`, `TaskItem`
- Indexes: `User.Email` (unique), `Project.UserId`, `TaskItem.ProjectId`, `TaskItem.UserId`

## API

| Method | Route | Auth | Description |
|--------|-------|------|-------------|
| POST | `/api/auth/register` | No | Register new user |
| POST | `/api/auth/login` | No | Login, returns JWT |
| GET | `/api/projects` | JWT | List user's projects (with task counts) |
| GET | `/api/projects/{id}` | JWT | Get project by ID |
| POST | `/api/projects` | JWT | Create project |
| PUT | `/api/projects/{id}` | JWT | Update project |
| DELETE | `/api/projects/{id}` | JWT | Delete project + its tasks |
| GET | `/api/projects/{pid}/tasks` | JWT | List project's tasks |
| GET | `/api/projects/{pid}/tasks/{tid}` | JWT | Get task by ID |
| POST | `/api/projects/{pid}/tasks` | JWT | Create task in project |
| PUT | `/api/projects/{pid}/tasks/{tid}` | JWT | Update task |
| DELETE | `/api/projects/{pid}/tasks/{tid}` | JWT | Delete task |

## Enums

- `TaskItemStatus`: `Pending`, `InProgress`, `Completed`
- Serialized as camelCase JSON strings (e.g. `"inProgress"`)

## Commands

```bash
dotnet build                          # build the project
dotnet run --launch-profile http      # dev server on http://localhost:5231
dotnet run --launch-profile https     # dev server on https://localhost:7283
```

## Conventions

- File-scoped namespaces (no block braces)
- Explicit constructors (no primary constructors yet)
- DTOs / Mappings use flat `ProjectTrackerApi.DTOs` / `ProjectTrackerApi.Mappings` namespaces
- Repositories / Services in `ProjectTrackerApi.Repositories` / `ProjectTrackerApi.Services`
- Repos registered as `AddScoped` (EF Core DbContext)
