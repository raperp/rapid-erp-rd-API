namespace RapidERP.Domain.Entities.Shared;

public class Captured : Master
{
    public int ActivityTypeId { get; set; }
    public string StorageURL { get; set; }
    public string FileHash { get; set; }
}
