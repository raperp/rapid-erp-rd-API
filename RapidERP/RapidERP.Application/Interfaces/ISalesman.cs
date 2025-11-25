using RapidERP.Application.DTOs.SalesmanDTOs;
using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.Interfaces;
public interface ISalesman : IBase<SalesmanPOST, SalesmanPUT, DeleteDTO> { }
