using ProjectTrackerApi.DTOs;
namespace ProjectTrackerApi.Services;

public interface IProjectService
{
    Task<List<ProjectResponseDto>> GetAllAsync(Guid userId);
    Task<ProjectResponseDto?> GetByIdAsync(Guid projectId, Guid userId);
    Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto, Guid userId);
    Task<ProjectResponseDto?> UpdateAsync(Guid projectId, UpdateProjectDto dto, Guid userId);
    Task<bool> DeleteAsync(Guid projectId, Guid userId);
}
