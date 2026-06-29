using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Enums;
using ProjectTrackerApi.Mappings;
using ProjectTrackerApi.Repositories;
namespace ProjectTrackerApi.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly ITaskRepository _taskRepository;

    public ProjectService(IProjectRepository projectRepository, ITaskRepository taskRepository)
    {
        _projectRepository = projectRepository;
        _taskRepository = taskRepository;
    }

    public async Task<List<ProjectResponseDto>> GetAllAsync(Guid userId)
    {
        var projects = await _projectRepository.GetByUserId(userId);
        var result = new List<ProjectResponseDto>();

        foreach (var project in projects)
        {
            var tasks = await _taskRepository.GetByProjectId(project.Id);
            var taskCount = tasks.Count;
            var completedCount = tasks.Count(t => t.Status == TaskItemStatus.Completed);
            result.Add(ProjectsMapper.ToDto(project, taskCount, completedCount));
        }

        return result;
    }

    public async Task<ProjectResponseDto?> GetByIdAsync(Guid projectId, Guid userId)
    {
        var project = await _projectRepository.GetById(projectId);
        if (project == null || project.UserId != userId)
            return null;

        var tasks = await _taskRepository.GetByProjectId(projectId);
        var taskCount = tasks.Count;
        var completedCount = tasks.Count(t => t.Status == TaskItemStatus.Completed);

        return ProjectsMapper.ToDto(project, taskCount, completedCount);
    }

    public async Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto, Guid userId)
    {
        var project = new Models.Project
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            UserId = userId,
            CreatedAt = DateTime.Now,
        };

        var created = await _projectRepository.Create(project);
        return ProjectsMapper.ToDto(created);
    }

    public async Task<ProjectResponseDto?> UpdateAsync(Guid projectId, UpdateProjectDto dto, Guid userId)
    {
        var project = await _projectRepository.GetById(projectId);
        if (project == null || project.UserId != userId)
            return null;

        project.Name = dto.Name;
        project.Description = dto.Description;

        await _projectRepository.Update(project);

        var tasks = await _taskRepository.GetByProjectId(projectId);
        var taskCount = tasks.Count;
        var completedCount = tasks.Count(t => t.Status == TaskItemStatus.Completed);

        return ProjectsMapper.ToDto(project, taskCount, completedCount);
    }

    public async Task<bool> DeleteAsync(Guid projectId, Guid userId)
    {
        var project = await _projectRepository.GetById(projectId);
        if (project == null || project.UserId != userId)
            return false;

        await _taskRepository.DeleteByProjectId(projectId);
        await _projectRepository.Delete(project);
        return true;
    }
}
