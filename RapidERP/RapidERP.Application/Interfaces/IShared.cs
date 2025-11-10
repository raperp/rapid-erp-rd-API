using RapidERP.Application.DTOs.Shared;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface IShared
{
    Task<CounterDTO> GetCounts<T>() where T : class;
}
