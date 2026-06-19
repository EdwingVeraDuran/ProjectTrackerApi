using ProjectTrackerApi.Enums;

namespace ProjectTrackerApi.DTOs;

public class UpdateProjectDto
{
    public string Name { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; }
}
