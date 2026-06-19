using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Models;

namespace ProjectTrackerApi.Repositories;

public interface IProjectRepository
{
    Task<List<ProjectResponseDto>> GetAll();
    Task<Project?> GetById(int projectId);
    Task<ProjectResponseDto> Create(CreateProjectDto dto);
    Task UpdateName(int projectId, UpdateProjectNameDto dto);
    Task UpdateStatus(int projectId, UpdateProjectStatusDto dto);
    Task Delete(int projectId);
}
