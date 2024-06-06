using ExpensesManager.Server.DTOs.Auth;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthFacade authFacade) : ApiControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<RegistrationSuccessDto> Register(RegistrationDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var retval = authFacade.Register(request);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<LoginSuccessDto> Login(LoginDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var retval = authFacade.Login(request);
        return FacadeResponseToActionResult(retval);
    }
}
