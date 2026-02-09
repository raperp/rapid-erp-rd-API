using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CalendarModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CalendarFeatures.GetAllQuery;

public class GetAllCalendarHandler(IRepository repository)
{
    GetAllCalendarResponseModel _response;

    public async Task<GetAllCalendarResponseModel> Handle(GetAllCalendarRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from c in repository.Set<Calendar>()
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        //join mm in repository.Set<MenuModule>() on c.MenuModuleId equals mm.Id
                        //join l in repository.Set<Language>() on c.LanguageId equals l.Id
                        //join st in repository.Set<StatusType>() on c.StatusTypeId equals st.Id
                        select new GetAllCalendarResponseDTOModel
                        {
                            Id = c.Id,
                            Tenant = t.Name,
                            //MenuModule = mm.Name,
                            //Language = l.Name,
                            //Status = st.Name,
                            Code = c.Code,
                            Name = c.Name,
                            StartDate = c.StartDate,
                            EndDate = c.EndDate,
                            TotalMonth = c.TotalMonth
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<Calendar>();
                result.Data = await data.ToListAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
                };
            }

            else
            {
                result.Count = await repository.GetCounts<Calendar>();
                result.Data = await data.Skip(query.skip).Take(query.take).ToListAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return _response;
        }

        catch (Exception ex)
        {
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _response;
        }
    }
}
