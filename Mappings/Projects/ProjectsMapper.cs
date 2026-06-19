using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Models;

namespace ProjectTrackerApi.Mappings;

public static class ProjectsMapper
{
    public static ProjectResponseDto ToProjectDTO(Project project)
    {
        return new ProjectResponseDto()
        {
            Id = project.Id,
            Name = project.Name,
            CreatedAt = project.CreatedAt,
        };
    }
}
