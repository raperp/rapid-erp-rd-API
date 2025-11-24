using RapidERP.Application.DTOs.OrderTypeDTOs;
using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.Interfaces;
public interface IOrderType : IBase<OrderTypePOST, OrderTypePUT, SoftDeleteRestore> { }
