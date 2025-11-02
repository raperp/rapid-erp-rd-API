using RapidERP.Application.DTOs.ExportTypeDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface IExportType
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<RequestResponse> GetSingle(int id);
    Task<RequestResponse> GetAllAudits(int skip, int take);
    Task<RequestResponse> GetAllExports(int skip, int take);
    Task<RequestResponse> CreateSingle(ExportTypePOST masterPOST);
    Task<RequestResponse> CreateBulk(List<ExportTypePOST> masterPOSTs);
    Task<RequestResponse> CreateExport(ExportDTO export);
    Task<RequestResponse> Update(ExportTypePUT masterPUT);
    Task<RequestResponse> Delete(int id);
}
