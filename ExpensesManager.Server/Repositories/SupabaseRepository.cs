using ExpensesManager.Server.DTOs;

namespace ExpensesManager.Server.Repositories;

public class SupabaseRepository : ICloudRepository
{
    public Task<bool> BackupUserData(UserImportDataDto data, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RestoreUserData(string userId)
    {
        throw new NotImplementedException();
    }
}
