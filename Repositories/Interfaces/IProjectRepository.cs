using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Models;

namespace ProjectTrackerApi.Repositories;

public interface IProjectRepository
{
    Task<List<ProjectResponseDto>> GetAll();
    Task<Project?> GetById(int projectId);
    Task<ProjectResponseDto> Create(CreateProjectDto dto);
    Task Update(int projectId, UpdateProjectDto dto);
    Task Delete(int projectId);
}
