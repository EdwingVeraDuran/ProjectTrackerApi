using ProjectTrackerApi.Models;
namespace ProjectTrackerApi.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(Guid userId);
    Task<User?> GetByEmail(string email);
    Task<User> Create(User user);
}
