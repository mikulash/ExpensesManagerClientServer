using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Models;
using Newtonsoft.Json;
using Supabase;

namespace ExpensesManager.Server.Repositories;

public class SupabaseRepository(Client client) : ICloudRepository
{
    public async Task<bool> BackupUserData(UserImportDataDto data, string userId)
    {
        var backupData = new UserCloudBackup
        {
            UserId = userId,
            UserData = JsonConvert.SerializeObject(data),
            UserDataType = "UserImportDataDto",
            CreatedAt = DateTime.Now
        };
        var response = await client.From<UserCloudBackup>().Insert(backupData);
        var newBackup = response.Models.FirstOrDefault();
        return newBackup != null;
    }

    public Task<UserImportDataDto> RestoreUserData(string userId)
    {
        throw new NotImplementedException();
    }
}
