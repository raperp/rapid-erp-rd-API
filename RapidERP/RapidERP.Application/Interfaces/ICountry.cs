using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.Interfaces;
public interface ICountry : IBase<CountryPOST, CountryPUT, DeleteDTO> { }
