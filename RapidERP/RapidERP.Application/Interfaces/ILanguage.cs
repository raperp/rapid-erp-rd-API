using RapidERP.Application.DTOs.LanguageDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface ILanguage 
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<RequestResponse> GetSingle(int id);
    Task<RequestResponse> GetAllAudits(int skip, int take);
    Task<RequestResponse> GetAllExports(int skip, int take);
    Task<RequestResponse> CreateSingle(LanguagePOST masterPOST); 
    Task<RequestResponse> CreateBulk(List<LanguagePOST> masterPOSTs);
    Task<RequestResponse> Update(LanguagePUT masterPUT);
    Task<RequestResponse> Delete(int id);  
}
