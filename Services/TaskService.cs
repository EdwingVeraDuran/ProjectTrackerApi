using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Enums;
using ProjectTrackerApi.Mappings;
using ProjectTrackerApi.Repositories;
namespace ProjectTrackerApi.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public TaskService(ITaskRepository taskRepository, IProjectRepository projectRepository)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<List<TaskResponseDto>> GetByProjectIdAsync(Guid projectId, Guid userId)
    {
        var project = await _projectRepository.GetById(projectId);
        if (project == null || project.UserId != userId)
            return [];

        var tasks = await _taskRepository.GetByProjectId(projectId);
        return tasks.Select(TasksMapper.ToDto).ToList();
    }

    public async Task<TaskResponseDto?> GetByIdAsync(Guid projectId, Guid taskId, Guid userId)
    {
        var project = await _projectRepository.GetById(projectId);
        if (project == null || project.UserId != userId)
            return null;

        var task = await _taskRepository.GetById(taskId);
        if (task == null || task.ProjectId != projectId)
            return null;

        return TasksMapper.ToDto(task);
    }

    public async Task<TaskResponseDto?> CreateAsync(Guid projectId, CreateTaskDto dto, Guid userId)
    {
        var project = await _projectRepository.GetById(projectId);
        if (project == null || project.UserId != userId)
            return null;

        var task = new Models.TaskItem
        {
            Id = Guid.NewGuid(),
            ProjectId = projectId,
            Title = dto.Title,
            Description = dto.Description,
            Status = TaskItemStatus.Pending,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
        };

        var created = await _taskRepository.Create(task);
        return TasksMapper.ToDto(created);
    }

    public async Task<TaskResponseDto?> UpdateAsync(Guid projectId, Guid taskId, UpdateTaskDto dto, Guid userId)
    {
        var project = await _projectRepository.GetById(projectId);
        if (project == null || project.UserId != userId)
            return null;

        var task = await _taskRepository.GetById(taskId);
        if (task == null || task.ProjectId != projectId)
            return null;

        if (dto.Title != null)
            task.Title = dto.Title;
        if (dto.Description != null)
            task.Description = dto.Description;
        if (dto.Status.HasValue)
            task.Status = dto.Status.Value;

        await _taskRepository.Update(task);
        return TasksMapper.ToDto(task);
    }

    public async Task<bool> DeleteAsync(Guid projectId, Guid taskId, Guid userId)
    {
        var project = await _projectRepository.GetById(projectId);
        if (project == null || project.UserId != userId)
            return false;

        var task = await _taskRepository.GetById(taskId);
        if (task == null || task.ProjectId != projectId)
            return false;

        await _taskRepository.Delete(task);
        return true;
    }
}
