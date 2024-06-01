namespace ExpensesManager.Server.DTOs.Auth;

public class RegistrationSuccessDto
{
    public string Message { get; set; }

    public RegistrationSuccessDto(string message)
    {
        Message = message;
    }
}