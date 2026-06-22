using ProjectTrackerApi.DTOs;

namespace ProjectTrackerApi.Services;

public interface ITaskService
{
    Task<TaskResponseDto?> GetById(int taskId);
    Task<List<TaskResponseDto>> GetByProjectId(int projectId);
    Task<TaskResponseDto> CreateAsync(CreateTaskDto dto);
    Task UpdateTitleAsync(int taskId, UpdateTaskTitleDto dto);
    Task UpdateStatusAsync(int taskId, UpdateTaskStatusDto dto);
    Task DeleteAsync(int taskId);
}
