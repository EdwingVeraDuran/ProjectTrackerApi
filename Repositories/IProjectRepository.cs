using ProjectTrackerApi.Models;
namespace ProjectTrackerApi.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetByUserId(Guid userId);
    Task<Project?> GetById(Guid projectId);
    Task<Project> Create(Project project);
    Task Update(Project project);
    Task Delete(Project project);
}
