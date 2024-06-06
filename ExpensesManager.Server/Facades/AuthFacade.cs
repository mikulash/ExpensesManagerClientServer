using ExpensesManager.Server.DTOs.Auth;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;

namespace ExpensesManager.Server.Facades;

public interface IAuthFacade
{
    public FacadeResponse<RegistrationSuccessDto> Register(RegistrationDto request);
    public FacadeResponse<LoginSuccessDto> Login(LoginDto request);
}

public class AuthFacade(IAuthService authService) : IAuthFacade
{
    public FacadeResponse<RegistrationSuccessDto> Register(RegistrationDto request)
    {
        var retval = new FacadeResponse<RegistrationSuccessDto>();
        if (request.Password != request.ConfirmPassword) return retval.SetBadRequest("Passwords do not match");
        var registrationSuccess = authService.Register(request);
        return registrationSuccess == null
            ? retval.SetServerError("User creation failed")
            : retval.SetOk(registrationSuccess);
    }

    public FacadeResponse<LoginSuccessDto> Login(LoginDto request)
    {
        var retval = new FacadeResponse<LoginSuccessDto>();
        var loginSuccess = authService.Login(request);
        return loginSuccess == null ? retval.SetBadRequest("Invalid login attempt") : retval.SetOk(loginSuccess);
    }
}
