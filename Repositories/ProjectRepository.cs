using Microsoft.EntityFrameworkCore;
using ProjectTrackerApi.Data;
using ProjectTrackerApi.Models;
namespace ProjectTrackerApi.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _db;

    public ProjectRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Project>> GetByUserId(Guid userId)
    {
        return await _db.Projects
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<Project?> GetById(Guid projectId)
    {
        return await _db.Projects.FindAsync(projectId);
    }

    public async Task<Project> Create(Project project)
    {
        _db.Projects.Add(project);
        await _db.SaveChangesAsync();
        return project;
    }

    public async Task Update(Project project)
    {
        _db.Projects.Update(project);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Project project)
    {
        _db.Projects.Remove(project);
        await _db.SaveChangesAsync();
    }
}
