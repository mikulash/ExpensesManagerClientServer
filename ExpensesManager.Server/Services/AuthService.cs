using ExpensesManager.Server.DTOs.Auth;
using ExpensesManager.Server.Mappings;
using Microsoft.AspNetCore.Identity;

namespace ExpensesManager.Server.Services;

public interface IAuthService
{
    public RegistrationSuccessDto? Register(RegistrationDto request);
    public LoginSuccessDto? Login(LoginDto request);
}

public class AuthService(
    UserManager<IdentityUser> userManager,
    IUserService userService,
    SignInManager<IdentityUser> signInManager,
    JwtTokenGenerator jwtTokenGenerator) : IAuthService
{
    public RegistrationSuccessDto? Register(RegistrationDto request)
    {
        var user = new IdentityUser { UserName = request.Email, Email = request.Email };
        var result = userManager.CreateAsync(user, request.Password).Result;
        if (!result.Succeeded) return null;
        userService.InitNewUser(user.Id);
        return new RegistrationSuccessDto("User created successfully");
    }

    public LoginSuccessDto? Login(LoginDto request)
    {
        var user = userManager.FindByEmailAsync(request.Email).Result;
        if (user == null) return null;

        var result = signInManager.CheckPasswordSignInAsync(user, request.Password, false).Result;
        if (!result.Succeeded) return null;

        var token = jwtTokenGenerator.GenerateToken(user);
        var userDto = UserMapping.ToUserDto(user);
        return new LoginSuccessDto { Token = token, Message = "Login successful", User = userDto };
    }
}
