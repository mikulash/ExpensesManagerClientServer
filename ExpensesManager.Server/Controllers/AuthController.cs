using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.DTOs.Auth;
using ExpensesManager.Server.Facades;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ApiControllerBase
{
    private readonly JwtTokenGenerator _jwtTokenGenerator;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserFacade _userFacade;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        JwtTokenGenerator jwtTokenGenerator, IUserFacade userFacade)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
        _userFacade = userFacade;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<RegistrationSuccessDto>> Register(RegistrationDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (request.Password != request.ConfirmPassword)
            return BadRequest(new { Success = false, Message = "Passwords do not match" });

        var user = new IdentityUser { UserName = request.Email, Email = request.Email };
        var result = await _userManager.CreateAsync(user, request.Password);
        _userFacade.InitNewUser(user.Id);

        if (!result.Succeeded) return BadRequest(result.Errors);

        return Ok(new RegistrationSuccessDto("User created successfully"));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null) return BadRequest(new ErrorResponseDto("Invalid login attempt"));

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded) return BadRequest(new ErrorResponseDto("Invalid login attempt"));

        var token = _jwtTokenGenerator.GenerateToken(user);
        var userDto = UserMapping.ToUserDto(user);
        return Ok(new LoginSuccessDto { Token = token, Message = "Login successful", User = userDto });
    }

}
