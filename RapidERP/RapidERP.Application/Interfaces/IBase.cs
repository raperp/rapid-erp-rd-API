using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface  IBase<POSTEntity, PUTEntity> where POSTEntity : class
{
    Task<RequestResponse> GetAll(int skip, int take);
    //Task<RequestResponse> GetAllAudits();
    Task<RequestResponse> GetById(int id); 
    Task<RequestResponse> Create(POSTEntity masterPOST);
    //Task<RequestResponse> CreateAudit(CountryAuditDTO masterPOST);
    Task<RequestResponse> Lookup();
    Task<RequestResponse> Update(PUTEntity masterPUT);
    Task<RequestResponse> Delete(int id);
    Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus);
    Task<RequestResponse> Import(List<CountryImport> imports);
}
