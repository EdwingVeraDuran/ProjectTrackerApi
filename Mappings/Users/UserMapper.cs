using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Models;
namespace ProjectTrackerApi.Mappings;

public static class UserMapper
{
    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }
}
