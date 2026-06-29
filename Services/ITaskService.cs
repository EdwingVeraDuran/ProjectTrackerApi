using ProjectTrackerApi.DTOs;
namespace ProjectTrackerApi.Services;

public interface ITaskService
{
    Task<List<TaskResponseDto>> GetByProjectIdAsync(Guid projectId, Guid userId);
    Task<TaskResponseDto?> GetByIdAsync(Guid projectId, Guid taskId, Guid userId);
    Task<TaskResponseDto?> CreateAsync(Guid projectId, CreateTaskDto dto, Guid userId);
    Task<TaskResponseDto?> UpdateAsync(Guid projectId, Guid taskId, UpdateTaskDto dto, Guid userId);
    Task<bool> DeleteAsync(Guid projectId, Guid taskId, Guid userId);
}
