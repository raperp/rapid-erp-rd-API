using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.TableDTOs;

namespace RapidERP.Application.Interfaces;

public interface ITable : IBase<TablePOST, TablePUT, SoftDeleteRestore> { }
