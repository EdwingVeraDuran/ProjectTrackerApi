using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Mappings;
using ProjectTrackerApi.Repositories;

namespace ProjectTrackerApi.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public TaskService(ITaskRepository repository, IProjectRepository projectRepository)
    {
        _taskRepository = repository;
        _projectRepository = projectRepository;
    }

    public async Task<TaskResponseDto> CreateAsync(CreateTaskDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title))
            throw new Exception("Task title is mandatory.");

        var project = await _projectRepository.GetById(dto.ProjectId);

        if (project == null)
            throw new Exception("Project not found.");

        return await _taskRepository.Create(dto);
    }

    public async Task DeleteAsync(int taskId)
    {
        var task = await _taskRepository.GetTaskById(taskId);

        if (task == null)
            throw new Exception("Task doesn't exist.");

        await _taskRepository.Delete(taskId);
    }

    public async Task<TaskResponseDto?> GetById(int taskId)
    {
        var task = await _taskRepository.GetTaskById(taskId);
        if (task == null)
            throw new Exception("Task doesn' exist.");
        return await Task.FromResult(TasksMapper.ToTaskDto(task));
    }

    public async Task<List<TaskResponseDto>> GetByProjectId(int projectId)
    {
        return await _taskRepository.GetByProjectId(projectId);
    }

    public async Task UpdateStatusAsync(int taskId, UpdateTaskStatusDto dto)
    {
        var task = await _taskRepository.GetTaskById(taskId);

        if (task == null)
            throw new Exception("Task doesn't exist.");

        await _taskRepository.UpdateStatus(taskId, dto);
    }

    public async Task UpdateTitleAsync(int taskId, UpdateTaskTitleDto dto)
    {
        var task = await _taskRepository.GetTaskById(taskId);

        if (task == null)
            throw new Exception("Task doesn't exist.");

        await _taskRepository.UpdateTitle(taskId, dto);
    }
}
