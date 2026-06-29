using Microsoft.EntityFrameworkCore;
using ProjectTrackerApi.Data;
using ProjectTrackerApi.Models;
namespace ProjectTrackerApi.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _db;

    public TaskRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<TaskItem>> GetByProjectId(Guid projectId)
    {
        return await _db.TaskItems
            .Where(t => t.ProjectId == projectId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<TaskItem?> GetById(Guid taskId)
    {
        return await _db.TaskItems.FindAsync(taskId);
    }

    public async Task<TaskItem> Create(TaskItem task)
    {
        _db.TaskItems.Add(task);
        await _db.SaveChangesAsync();
        return task;
    }

    public async Task Update(TaskItem task)
    {
        _db.TaskItems.Update(task);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(TaskItem task)
    {
        _db.TaskItems.Remove(task);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteByProjectId(Guid projectId)
    {
        await _db.TaskItems.Where(t => t.ProjectId == projectId).ExecuteDeleteAsync();
    }
}
