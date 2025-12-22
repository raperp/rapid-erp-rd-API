using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Application.Features.CountryFeatures.GetAllQuery;

public class GetAllCountryHandler(IRepository repository)
{
    public async Task<List<GetAllCountryResponseModel>> Handle(GetAllCountryRequestModel query)
    {
        try
        {
            var data = (from c in repository.Set<Country>()
                        join st in repository.Set<StatusType>() on c.StatusTypeId equals st.Id
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        join l in repository.Set<Language>() on c.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on c.MenuModuleId equals mm.Id
                        join cu in repository.Set<Currency>() on c.CurrencyId equals cu.Id
                        select new GetAllCountryResponseModel
                        {
                            Id = c.Id,
                            MenuModule = mm.Name,
                            Tanent = t.Name,
                            Language = l.Name,
                            Status = st.Name,
                            Currency = cu.Name,
                            DialCode = c.DialCode,
                            Country = c.Name,
                            IsDefault = c.IsDefault,
                            IsDraft = c.IsDraft,
                            ISONumeric = c.ISONumeric,
                            ISO2Code = c.ISO2Code,
                            ISO3Code = c.ISO3Code,
                            FlagURL = c.FlagURL
                        }).AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                //result.Count = await shared.GetCounts<Country>(pageSize);
                return data.ToList();

                //_requestResponse = new()
                //{
                //    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                //    IsSuccess = true,
                //    Message = ResponseMessage.FetchSuccess,
                //    Data = result
                //};
            }

            else
            {
                //result.Count = await shared.GetCounts<Country>(pageSize);
                return data.Skip(query.skip).Take(query.take).ToList();

                //_requestResponse = new()
                //{
                //    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                //    IsSuccess = true,
                //    Message = ResponseMessage.FetchSuccessWithPagination,
                //    Data = result
                //};
            }

            //return _requestResponse;
        }

        catch (Exception ex)
        {
            //_requestResponse = new()
            //{
            //    StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
            //    IsSuccess = false,
            //    Message = ex.Message
            //};

            //return _requestResponse;
            throw new ApplicationException(ex.Message);
        }
    }
}
