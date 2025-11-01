using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ClientModels;
using RapidERP.Domain.Entities.DocumentTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.ModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;

namespace RapidERP.Domain.Entities.Shared;
public class Base : Master
{
    public Client Client { get; set; }
    public int ClientId { get; set; }
    public Module Module { get; set; }
    public int ModuleId { get; set; }
    public DocumentType DocumentType { get; set; }
    public int DocumentTypeId { get; set; }
    public ActionType ActionType { get; set; }
    public int ActionTypeId { get; set; }
    public StatusType StatusType { get; set; }
    public int StatusTypeId { get; set; }
    public Language Language { get; set; }
    public int LanguageId { get; set; }
    public bool? IsDefault { get; set; }
    public long ActionUserId { get; set; }
    public DateTime ActionAt { get; set; }
}
