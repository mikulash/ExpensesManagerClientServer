using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Models;
using Newtonsoft.Json;
using Postgrest;
using Client = Supabase.Client;

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

    public async Task<UserImportDataDto?> RestoreUserData(string userId)
    {
        var result = await client.From<UserCloudBackup>().Select("*").Where(x => x.UserId == userId)
            .Order(x => x.CreatedAt, Constants.Ordering.Descending)
            .Limit(1).Get();
        var backupData = result.Models.FirstOrDefault();
        if (backupData == null) return null;
        return JsonConvert.DeserializeObject<UserImportDataDto>(backupData.UserData);
    }
}
