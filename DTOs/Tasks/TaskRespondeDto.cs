using ProjectTrackerApi.Enums;

namespace ProjectTrackerApi.DTOs;

public class TaskResponseDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Title { get; set; } = string.Empty;
    public TaskItemStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
