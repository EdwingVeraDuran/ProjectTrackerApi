using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Enums;
using ProjectTrackerApi.Mappings;
using ProjectTrackerApi.Models;

namespace ProjectTrackerApi.Repositories;

public class LocalProjectRepository : IProjectRepository
{
    private readonly List<Project> _projects = new();
    private int _nextId = 1;

    public Task<ProjectResponseDto> Create(CreateProjectDto dto)
    {
        var project = new Project
        {
            Id = _nextId,
            Name = dto.Name,
            Status = ProjectStatus.Planning,
            CreatedAt = DateTime.Now,
        };

        _nextId++;

        _projects.Add(project);

        return Task.FromResult(ProjectsMapper.ToProjectDTO(project));
    }

    public async Task Delete(int projectId)
    {
        var project = await GetById(projectId);

        if (project == null)
            return;

        _projects.Remove(project);
    }

    public Task<List<ProjectResponseDto>> GetAll()
    {
        return Task.FromResult(
            _projects.Select(project => ProjectsMapper.ToProjectDTO(project)).ToList()
        );
    }

    public Task<Project?> GetById(int projectId)
    {
        var project = _projects.FirstOrDefault(p => p.Id == projectId);
        return Task.FromResult(project);
    }

    public async Task UpdateName(int projectId, UpdateProjectNameDto dto)
    {
        var project = await GetById(projectId);

        if (project == null)
            return;

        project.Name = dto.Name;
    }

    public async Task UpdateStatus(int projectId, UpdateProjectStatusDto dto)
    {
        var project = await GetById(projectId);

        if (project == null)
            return;

        project.Status = dto.Status;
    }
}
