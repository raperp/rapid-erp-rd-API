using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.SupplierDTOs;

namespace RapidERP.Application.Interfaces;
public interface ISupplier : IBase<SupplierPOST, SupplierPUT, SoftDeleteRestore> { }
