using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Domain.Entities.Shared
{
    public class BaseMaster  
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StatusTypeId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
