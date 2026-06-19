# ProjectTrackerApi

A .NET 10 Web API for tracking projects and tasks — built with ASP.NET Core, in-memory storage, and no database dependencies.

## Stack

- .NET 10 / ASP.NET Core
- In-memory storage (no EF Core, no DB)
- Hand-written mappings (no AutoMapper)

## Architecture

```
Models → DTOs → Repositories → Services → Controllers
              → Mappings
```

## Commands

```bash
dotnet build
dotnet run --launch-profile http   # http://localhost:5231
dotnet run --launch-profile https  # https://localhost:7283
```

## Status

- **Projects**: CRUD completo
- **Tasks**: Repositorio listo, falta service y controller
