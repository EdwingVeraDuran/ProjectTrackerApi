using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Enums;
using ProjectTrackerApi.Mappings;
using ProjectTrackerApi.Models;

namespace ProjectTrackerApi.Repositories;

public class LocalTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public Task<TaskResponseDto> Create(CreateTaskDto dto)
    {
        var taskItem = new TaskItem
        {
            Id = _nextId,
            ProjectId = dto.ProjectId,
            Title = dto.Title,
            Status = TaskItemStatus.Pending,
            CreatedAt = DateTime.Now,
        };

        _nextId++;

        _tasks.Add(taskItem);

        return Task.FromResult(TasksMapper.ToTaskDto(taskItem));
    }

    public async Task Delete(int taskId)
    {
        var task = await GetTaskById(taskId);

        if (task == null)
            return;

        _tasks.Remove(task);
    }

    public async Task<List<TaskResponseDto>> GetByProjectId(int projectId)
    {
        var tasks = _tasks.Where(task => task.ProjectId == projectId).ToList();
        return tasks.Select(task => TasksMapper.ToTaskDto(task)).ToList();
    }

    public async Task<TaskItem?> GetTaskById(int taskId)
    {
        return await Task.FromResult(_tasks.FirstOrDefault(task => task.Id == taskId));
    }

    public async Task UpdateStatus(int taskId, UpdateTaskStatusDto dto)
    {
        var task = await GetTaskById(taskId);
        if (task == null)
            return;

        task.Status = dto.Status;
    }

    public async Task UpdateTitle(int taskId, UpdateTaskTitleDto dto)
    {
        var task = await GetTaskById(taskId);
        if (task == null)
            return;

        task.Title = dto.Title;
    }
}
