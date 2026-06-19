# ProjectTrackerApi

## Stack

- .NET 10.0 ASP.NET Core Web API (minimal API style, `ImplicitUsings` + `Nullable` enabled)
- In-memory storage only — no database, no EF Core
- Single project file (`ProjectTrackerApi.csproj`), no `.sln`

## Architecture

```
Models → DTOs → Repositories (Interfaces/) → LocalMemRepo/
              → Mappings (static classes)
              → Services (Interfaces/) → Program.cs
```

- **Mappings** are hand-written static extension methods (no AutoMapper)
- **Repositories** use `DateTime.Now` (not UTC) for `CreatedAt`
- **Services** add validation + business logic on top of repos
- **Controllers** use the standard `[ApiController]` + `Controller` pattern

## Project state

- Project layer (`IProjectRepository` + `LocalProjectRepository` + `IProjectService` + `ProjectService` + `ProjectsController`): ✅ complete
- Task layer (`ITaskRepository` + `LocalTaskRepository`): repo exists, but **no `ITaskService`/`TaskService`** and **no `TasksController`**
- `Program.cs` has DI wired for project repos/services and controllers
- `ITaskRepository` is not yet registered in DI (no consumer yet)

## Commands

```bash
dotnet build                          # build the project
dotnet run --launch-profile http      # dev server on http://localhost:5231
dotnet run --launch-profile https     # dev server on https://localhost:7283
```

## Conventions

- File-scoped namespaces (no block braces)
- `Primary constructor` style not yet used; existing code uses explicit fields/ctors
- DTOs live in `ProjectTrackerApi.DTOs` namespace (flat, not sub-namespace per entity)
- Repository interfaces in `ProjectTrackerApi.Repositories`, implementations in same
- Service interfaces in `ProjectTrackerApi.Services`, implementations in same
- Repos are registered as singletons (`AddSingleton`) since they use in-memory state
