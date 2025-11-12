
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Application.Interfaces;
public interface IShared
{
    Task<dynamic> GetCounts<T>() where T : BaseMaster;
}
