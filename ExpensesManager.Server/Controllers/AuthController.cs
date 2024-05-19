using ExpensesManager.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            if(model.Password != model.ConfirmPassword)
            {
                return BadRequest(new { Success = false, Message = "Passwords do not match" });
            }

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok(new { Success = true, Message = "Registration successful" });
        }
        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return Ok(new { Success = true, Message = "Login successful" });
            }
            return BadRequest(new { Success = false, Message = "Invalid login attempt" });
        }
        return BadRequest(ModelState);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { Success = true, Message = "Logged out successfully" });
    }
}
