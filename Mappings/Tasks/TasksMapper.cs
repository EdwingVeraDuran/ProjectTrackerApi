using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Models;

namespace ProjectTrackerApi.Mappings;

public static class TasksMapper
{
    public static TaskResponseDto ToTaskDto(TaskItem taskItem)
    {
        return new TaskResponseDto()
        {
            Id = taskItem.Id,
            ProjectId = taskItem.ProjectId,
            Title = taskItem.Title,
            Status = taskItem.Status,
            CreatedAt = taskItem.CreatedAt,
        };
    }
}
