using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Repositories;

namespace ProjectTrackerApi.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto)
    {
        if (string.IsNullOrEmpty(dto.Name))
            throw new Exception("Project name is mandatory.");

        return await _projectRepository.Create(dto);
    }

    public async Task DeleteAsync(int projectId)
    {
        var project = await _projectRepository.GetById(projectId);

        if (project == null)
            throw new Exception("The project doesn't exist.");

        await _projectRepository.Delete(projectId);
    }

    public async Task<List<ProjectResponseDto>> GetAllAsync()
    {
        return await _projectRepository.GetAll();
    }

    public async Task UpdateNameAsync(int projectId, UpdateProjectNameDto dto)
    {
        var project = await _projectRepository.GetById(projectId);

        if (project == null)
            throw new Exception("The project doesn´t exist.");

        await _projectRepository.UpdateName(projectId, dto);
    }

    public async Task UpdateStatusAsync(int projectId, UpdateProjectStatusDto dto)
    {
        var project = await _projectRepository.GetById(projectId);

        if (project == null)
            throw new Exception("The project doesn't exist.");

        await _projectRepository.UpdateStatus(projectId, dto);
    }
}
