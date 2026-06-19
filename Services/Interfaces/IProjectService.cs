using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Enums;

namespace ProjectTrackerApi.Services;

public interface IProjectService
{
    Task<List<ProjectResponseDto>> GetAllAsync();
    Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto);
    Task UpdateStatusAsync(int projectId, ProjectStatus newStatus);
    Task DeleteAsync(int projectId);
}
