using ProjectTrackerApi.Enums;

namespace ProjectTrackerApi.DTOs;

public class UpdateTaskStatusDto
{
    public TaskItemStatus Status { get; set; }
}
