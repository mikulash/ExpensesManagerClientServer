using ExpensesManager.Server.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ExpensesManager.Server.Mappings;

public static class UserMapping
{
    public static UserDto ToUserDto(IdentityUser user)
    {
        return new UserDto
        {
            UserId = user.Id,
            Username = user.UserName,
            Email = user.Email
        };
    }
}
