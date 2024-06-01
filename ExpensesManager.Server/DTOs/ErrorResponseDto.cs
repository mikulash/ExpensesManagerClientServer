namespace ExpensesManager.Server.DTOs;

public class ErrorResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public ErrorResponseDto(string message)
    {
        Success = false;
        Message = message;
    }
}
