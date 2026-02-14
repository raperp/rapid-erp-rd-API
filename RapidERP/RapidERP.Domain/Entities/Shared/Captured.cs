namespace RapidERP.Domain.Entities.Shared;

public class Captured  
{
    public int Id { get; set; }
    public int ActivityTypeId { get; set; }
    public string StorageURL { get; set; }
    public string FileHash { get; set; }
}
