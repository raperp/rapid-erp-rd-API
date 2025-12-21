using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface ISharedService
{
    Task<dynamic> GetCounts<T>(int pageSize) where T : BaseMaster;
    Task<RequestResponse> GetSingle<T>(int id) where T : Master;
    Task<RequestResponse> SoftDelete<T>(int id) where T : BaseMaster;
    Task<RequestResponse> Delete<T>(int id) where T : Master;
}
