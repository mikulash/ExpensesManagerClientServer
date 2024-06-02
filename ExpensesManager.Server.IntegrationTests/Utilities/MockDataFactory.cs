using ExpensesManager.Server.DTOs.Auth;

namespace ExpensesManager.Server.IntegrationTests;

public static class MockDataFactory
{
    public static RegistrationDto CreateRegistrationDto(string email, string password)
    {
        return new RegistrationDto
        {
            Email = email,
            Password = password,
            ConfirmPassword = password
        };
    }

    public static LoginDto CreateLoginDto(string email, string password)
    {
        return new LoginDto
        {
            Email = email,
            Password = password
        };
    }

}
