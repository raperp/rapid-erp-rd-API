using RapidERP.Application.Interfaces.Country;

namespace RapidERP.Application.DTOs.CountryDTOs;

public class CountryServiceDTO
{
    public ICountry countryService;
    public ICountryLocalization localizationService;
    public ICountryExport exportService;
    public ICountryActivity activityService;
    public ICountryAudit auditService;
    public ICountryCapture captureService;
    public ICountryCurrency currencyService;
}
