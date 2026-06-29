using ProjectTrackerApi.Models;
namespace ProjectTrackerApi.Repositories;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetByProjectId(Guid projectId);
    Task<TaskItem?> GetById(Guid taskId);
    Task<TaskItem> Create(TaskItem task);
    Task Update(TaskItem task);
    Task Delete(TaskItem task);
    Task DeleteByProjectId(Guid projectId);
}
