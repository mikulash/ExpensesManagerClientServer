using ExpensesManager.Server.DTOs;

namespace ExpensesManager.Server.Repositories;

public interface ICloudRepository
{
    Task<bool> BackupUserData(UserImportDataDto data, string userId);
    Task<UserImportDataDto?> RestoreUserData(string userId);
}
