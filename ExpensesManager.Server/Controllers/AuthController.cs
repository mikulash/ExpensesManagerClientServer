using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        JwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid login attempt" });
            }

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
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid login attempt" });
            }

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

    [HttpGet("currentuser")]
    public IActionResult GetCurrentUser()
    {
        if (User.Identity is { IsAuthenticated: true })
        {
            return Ok(new { Success = true, UserName = User.Identity.Name });
        }

        return Unauthorized(new { Success = false, Message = "User is not authenticated" });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { Success = true, Message = "Logged out successfully" });
    }
}
