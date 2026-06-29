using ProjectTrackerApi.Enums;
namespace ProjectTrackerApi.Models;

public class TaskItem
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TaskItemStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public Project Project { get; set; } = null!;
    public User User { get; set; } = null!;
}
