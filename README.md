# ProjectTrackerApi

A .NET 10 Web API for tracking projects and tasks — built with ASP.NET Core, in-memory storage, and no database dependencies.

## Stack

- .NET 10 / ASP.NET Core
- In-memory storage (no EF Core, no DB)
- Hand-written mappings (no AutoMapper)

## Architecture

```
Models → DTOs → Repositories (Interfaces → LocalMemRepo)
              → Mappings (static extension methods)
              → Services
              → Controllers
```

## API Endpoints

### Projects (`/api/projects`)

| Method | Route                     | Action                     |
|--------|---------------------------|----------------------------|
| GET    | `/api/projects`           | Get all projects           |
| POST   | `/api/projects`           | Create a project           |
| PUT    | `/api/projects/{id}/name`  | Update project name        |
| PUT    | `/api/projects/{id}/status`| Update project status      |
| DELETE | `/api/projects/{id}`      | Delete a project           |

### Tasks (`/api/tasks`)

| Method | Route                    | Action                     |
|--------|--------------------------|----------------------------|
| GET    | `/api/tasks/{taskId}`    | Get task by ID             |
| GET    | `/api/tasks?projectId=`  | Get tasks by project ID    |
| POST   | `/api/tasks`             | Create a task              |
| PATCH  | `/api/tasks/{id}/title`  | Update task title          |
| PATCH  | `/api/tasks/{id}/status` | Update task status         |
| DELETE | `/api/tasks/{id}`        | Delete a task              |

### Enums

- **ProjectStatus**: `Active`, `Inactive`
- **TaskItemStatus**: `Pending`, `InProgress`, `Completed`

## DTOs

### Projects

| DTO                    | Fields                                   |
|------------------------|------------------------------------------|
| `CreateProjectDto`     | `Name`                                   |
| `UpdateProjectNameDto` | `Name`                                   |
| `UpdateProjectStatusDto`| `Status` (ProjectStatus)                 |
| `ProjectResponseDto`   | `Id`, `Name`, `Status`, `CreatedAt`      |

### Tasks

| DTO                    | Fields                                   |
|------------------------|------------------------------------------|
| `CreateTaskDto`        | `ProjectId`, `Title`                     |
| `UpdateTaskTitleDto`   | `Title`                                  |
| `UpdateTaskStatusDto`  | `Status` (TaskItemStatus)                |
| `TaskResponseDto`      | `Id`, `ProjectId`, `Title`, `Status`, `CreatedAt` |

## Commands

```bash
dotnet build                          # build the project
dotnet run --launch-profile http      # dev server on http://localhost:5231
dotnet run --launch-profile https     # dev server on https://localhost:7283
```

## Status

- **Projects**: CRUD completo
- **Tasks**: CRUD completo
