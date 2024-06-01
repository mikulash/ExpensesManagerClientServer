using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.DTOs.Auth;
using ExpensesManager.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenGenerator _jwtTokenGenerator;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        JwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationDto model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return BadRequest(new { Success = false, Message = "Invalid login attempt" });

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                var token = _jwtTokenGenerator.GenerateToken(user);
                return Ok(new { Success = true, Token = token, Message = "Login successful" });
            }

            return BadRequest(new { Success = false, Message = "Invalid login attempt" });
        }

        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null) return BadRequest(new ErrorResponseDto("Invalid login attempt"));

        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded) return BadRequest(new ErrorResponseDto("Invalid login attempt"));

        var token = _jwtTokenGenerator.GenerateToken(user);
        return Ok(new LoginSuccessDto { Token = token, Message = "Login successful" });
    }
    // TODO delete or invalidate token
    // [HttpPost("logout")]
    // public async Task<IActionResult> Logout()
    // {
    //     await _signInManager.SignOutAsync();
    //     return Ok(new { Success = true, Message = "Logged out successfully" });
    // }
}
