using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Enums;
using ProjectTrackerApi.Mappings;
using ProjectTrackerApi.Models;

namespace ProjectTrackerApi.Repositories;

public class LocalTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public void Create(int projectId, CreateTaskDto dto)
    {
        var taskItem = new TaskItem
        {
            Id = _nextId,
            ProjectId = projectId,
            Title = dto.Title,
            Status = TaskItemStatus.Pending,
            CreatedAt = DateTime.Now,
        };

        _nextId++;

        _tasks.Add(taskItem);
    }

    public void Delete(int taskId)
    {
        var task = GetTaskById(taskId);

        if (task == null)
            return;

        _tasks.Remove(task);
    }

    public List<TaskResponseDto> GetByProjectId(int projectId)
    {
        var tasks = _tasks.Where(task => task.ProjectId == projectId).ToList();
        return tasks.Select(task => TasksMapper.ToTaskDto(task)).ToList();
    }

    public TaskItem? GetTaskById(int taskId)
    {
        var task = _tasks.FirstOrDefault(task => task.Id == taskId);
        if (task == null)
            return null;
        return task;
    }

    public void Update(int projectId, int taskId, UpdateTaskDto dto)
    {
        var task = GetTaskById(taskId);
        if (task == null)
            return;

        task.Title = dto.Title;
        task.Status = dto.Status;
    }
}
