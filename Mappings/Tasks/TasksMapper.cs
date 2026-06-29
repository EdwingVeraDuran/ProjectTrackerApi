using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Models;
namespace ProjectTrackerApi.Mappings;

public static class TasksMapper
{
    public static TaskResponseDto ToDto(TaskItem task)
    {
        return new TaskResponseDto
        {
            Id = task.Id,
            ProjectId = task.ProjectId,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            CreatedAt = task.CreatedAt,
        };
    }
}
