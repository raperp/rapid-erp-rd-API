
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Application.Interfaces;
public interface IShared
{
    Task<dynamic> GetSum<T>() where T : GetDTO;
}
