using RapidERP.Application.DTOs.Shared;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface IShared
{
    Task<dynamic> GetCounts<T>() where T : BaseMaster;
    Task<RequestResponse> GetSingle<T>(int id) where T : BaseMaster;
    Task<RequestResponse> SoftDelete<T>(DeleteDTO softDelete) where T : BaseMaster;
}
