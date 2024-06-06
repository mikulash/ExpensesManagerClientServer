using Postgrest.Attributes;
using Postgrest.Models;

namespace ExpensesManager.Server.Models;

[Table("UsersBackup")]
public class UserCloudBackup : BaseModel
{
    [PrimaryKey("Id")] public long Id { get; set; }
    [Column("user_id")] public string UserId { get; set; }
    [Column("user_data")] public string UserData { get; set; }
    [Column("user_data_type")] public string UserDataType { get; set; }
    [Column("created_at")] public DateTime CreatedAt { get; set; }
}

public class CreateBackupRequest
{
    public string UserId { get; set; }
    public string UserData { get; set; }
    public string UserDataType { get; set; }
}

public class RestoreBackupRequest
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string UserDataType { get; set; }
    public string UserData { get; set; }
    public DateTime CreatedAt { get; set; }
}
