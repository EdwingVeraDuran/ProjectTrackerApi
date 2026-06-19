using ProjectTrackerApi.Enums;

namespace ProjectTrackerApi.DTOs;

public class UpdateProjectStatusDto
{
    public ProjectStatus Status { get; set; }
}
