using ProjectTrackerApi.Enums;
namespace ProjectTrackerApi.DTOs;

public class UpdateTaskDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public TaskItemStatus? Status { get; set; }
}
