using ProjectTrackerApi.Enums;

namespace ProjectTrackerApi.DTOs;

public class UpdateTaskDto
{
    public string Title { get; set; } = string.Empty;
    public TaskItemStatus Status { get; set; }
}
