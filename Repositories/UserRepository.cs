using Microsoft.EntityFrameworkCore;
using ProjectTrackerApi.Data;
using ProjectTrackerApi.Models;
namespace ProjectTrackerApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetById(Guid userId)
    {
        return await _db.Users.FindAsync(userId);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> Create(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }
}
