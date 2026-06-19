using ProjectTrackerApi.DTOs;

namespace ProjectTrackerApi.Services;

public interface IProjectService
{
    Task<List<ProjectResponseDto>> GetAllAsync();
    Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto);
    Task UpdateNameAsync(int projectId, UpdateProjectNameDto dto);
    Task UpdateStatusAsync(int projectId, UpdateProjectStatusDto dto);
    Task DeleteAsync(int projectId);
}
