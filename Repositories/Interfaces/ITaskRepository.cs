using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Models;

namespace ProjectTrackerApi.Repositories;

public interface ITaskRepository
{
    Task<List<TaskResponseDto>> GetByProjectId(int projectId);
    Task<TaskItem?> GetTaskById(int taskId);
    Task<TaskResponseDto> Create(CreateTaskDto dto);
    Task UpdateTitle(int taskId, UpdateTaskTitleDto dto);
    Task UpdateStatus(int taskId, UpdateTaskStatusDto dto);
    Task Delete(int taskId);
    Task DeleteByProjectId(int projectId);
}
