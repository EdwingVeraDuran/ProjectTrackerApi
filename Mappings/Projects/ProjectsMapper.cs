using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Models;
namespace ProjectTrackerApi.Mappings;

public static class ProjectsMapper
{
    public static ProjectResponseDto ToDto(Project project, int taskCount = 0, int completedCount = 0)
    {
        return new ProjectResponseDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt,
            TaskCount = taskCount,
            CompletedCount = completedCount,
        };
    }
}
