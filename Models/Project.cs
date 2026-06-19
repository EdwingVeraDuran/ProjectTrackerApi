using ProjectTrackerApi.Enums;

namespace ProjectTrackerApi.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
