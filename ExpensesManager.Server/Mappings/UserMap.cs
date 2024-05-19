using ExpensesManager.Server.DTOs;

namespace ExpensesManager.Server.Mappings;

public class UserMap
{
    public UserDto ToDto(Models.User user)
    {
        return new UserDto
        {
            UserId = user.UserId.ToString(),
            Username = user.Username,
            Password = user.Password,
            Email = user.Email
        };
    }

    public Models.User ToModel(UserDto userDto)
    {
        return new Models.User
        {
            UserId = int.Parse(userDto.UserId),
            Username = userDto.Username,
            Password = userDto.Password,
            Email = userDto.Email
        };
    }
}
