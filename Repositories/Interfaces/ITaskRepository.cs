using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Models;

namespace ProjectTrackerApi.Repositories;

public interface ITaskRepository
{
    List<TaskResponseDto> GetByProjectId(int projectId);
    TaskItem? GetTaskById(int taskId);
    void Create(int projectId, CreateTaskDto dto);
    void Update(int projectId, int taskId, UpdateTaskDto dto);
    void Delete(int taskId);
}
