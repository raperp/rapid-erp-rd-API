using RapidERP.Application.DTOs.DepartmentDTOs;
using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.Interfaces;
public interface IDepartment : IBase<DepartmentPOST, DepartmentPUT, SoftDeleteRestore> { }
