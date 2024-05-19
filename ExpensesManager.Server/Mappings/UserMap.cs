using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Mappings;

public class UserMap
{
    public UserDto ToDto(User user)
    {
        return new UserDto
        {
            UserId = user.UserId.ToString(),
            Username = user.Username,
            Password = user.Password,
            Email = user.Email
        };
    }

    public User ToModel(UserDto userDto)
    {
        return new User
        {
            UserId = int.Parse(userDto.UserId),
            Username = userDto.Username,
            Password = userDto.Password,
            Email = userDto.Email
        };
    }
}