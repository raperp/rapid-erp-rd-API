using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;

namespace RapidERP.Application.Interfaces;

public interface ICountryService : IBaseService<CountryPOSTRequestDTO, CountryPUTRequestDTO> { }
