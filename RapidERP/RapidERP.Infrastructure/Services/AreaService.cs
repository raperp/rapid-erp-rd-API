using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.AreaDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class AreaService(RapidERPDbContext context) : IArea
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<AreaPOST> masterPOSTs)
    {
        try
        {
            foreach (var masterPOST in masterPOSTs)
            {
                await CreateSingle(masterPOST);
            }

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                IsSuccess = true,
                Message = ResponseMessage.CreateSuccess,
                Data = masterPOSTs
            };

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> CreateSingle(AreaPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Areas.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Area masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.Code = masterPOST.Code;
                masterData.CountryId = masterPOST.CountryId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.StateId = masterPOST.StateId;
                masterData.CreatedBy = masterPOST.CreatedBy;
                masterData.CreatedAt = DateTime.Now;

                await context.Areas.AddAsync(masterData);
                await context.SaveChangesAsync();

                AreaAudit audit = new();
                audit.Name = masterPOST.Name;
                audit.Code = masterPOST.Code;
                audit.CountryId = masterPOST.CountryId;
                audit.StatusTypeId = masterPOST.StatusTypeId;
                audit.StateId = masterPOST.StateId;
                audit.AreaId = masterData.Id;
                audit.CityId = masterData.CityId;
                audit.StatusTypeId = masterPOST.StatusTypeId;
                audit.ActionTypeId = masterPOST.ActionTypeId;
                audit.ExportTypeId = masterPOST.ExportTypeId;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.IsDefault = masterPOST.IsDefault;
                audit.Browser = masterPOST.Browser;
                audit.DeviceName = masterPOST.DeviceName;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                audit.GoogleMapUrl = masterPOST.GoogleMapUrl;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                audit.ActionBy = masterPOST.CreatedBy;
                audit.ActionAt = DateTime.Now;

                await context.AreaAudits.AddAsync(audit);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = masterPOST
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = ResponseMessage.RecordExists
                };
            }

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> Delete(int id)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isAuditExists = await context.AreaAudits.AsNoTracking().AnyAsync(x => x.AreaId == id);

            if (isAuditExists == false)
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }

            else
            {
                await context.AreaAudits.Where(x => x.AreaId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Areas.AsNoTracking().AnyAsync(x => x.Id == id);

            if (isExists == false)
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }

            else
            {
                await context.Areas.Where(x => x.Id == id).ExecuteDeleteAsync();
                await transaction.CommitAsync();
            }

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.DeleteSuccess
            };

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> GetAll(int skip, int take)
    {
        try
        {
            var data = (from a in context.Areas
                        join st in context.StatusTypes on a.StatusTypeId equals st.Id
                        join co in context.Countries on a.CountryId equals co.Id
                        join sta in context.States on a.StateId equals sta.Id
                        join ci in context.Cities on a.CityId equals ci.Id
                        select new
                        {
                            a.Id,
                            a.Name,
                            Tanent = st.Name,
                            Country = co.Name,
                            State = sta.Name,
                            Status = st.Name,
                            a.CreatedBy,
                            a.CreatedAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                var result = await data.ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
                };
            }

            else
            {
                var result = await data.Skip(skip).Take(take).ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> GetAllAudits(int skip, int take)
    {
        try
        {
            var data = (from aa in context.AreaAudits
                        join c in context.Countries on aa.CountryId equals c.Id
                        join sta in context.States on aa.StateId equals sta.Id
                        join cit in context.Cities on aa.CityId equals cit.Id
                        //join et in context.ExportTypes on aa.ExportTypeId equals et.Id
                        join at in context.ActionTypes on aa.ActionTypeId equals at.Id
                        join st in context.StatusTypes on aa.StatusTypeId equals st.Id
                        select new
                        {
                            aa.Id,
                            Country = c.Name,
                            State = sta.Name,
                            City = cit.Name,
                            aa.Name,
                            //ExportType = et.Name,
                            ActionType = at.Name,
                            StatusType = st.Name,
                            aa.ExportTo,
                            aa.SourceURL,
                            aa.IsDefault,
                            aa.Browser,
                            aa.DeviceName,
                            aa.Location,
                            aa.DeviceIP,
                            aa.GoogleMapUrl,
                            aa.Latitude,
                            aa.Longitude,
                            aa.ActionBy,
                            aa.ActionAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                var result = await data.ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
                };
            }

            else
            {
                var result = await data.Skip(skip).Take(take).ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> GetSingle(int id)
    {
        try
        {
            var data = await context.Areas.Where(x => x.Id == id).AsNoTracking().ToListAsync();

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = data
            };

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> Update(AreaPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Areas.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Areas.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.CountryId, masterPUT.CountryId)
                .SetProperty(x => x.StateId, masterPUT.StateId)
                .SetProperty(x => x.CityId, masterPUT.CityId)
                .SetProperty(x => x.Code, masterPUT.Code)
                .SetProperty(x => x.UpdatedBy, masterPUT.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, DateTime.Now));

                AreaAudit audit = new();
                audit.Name = masterPUT.Name;
                audit.Code = masterPUT.Code;
                audit.CountryId = masterPUT.CountryId;
                audit.StatusTypeId = masterPUT.StatusTypeId;
                audit.StateId = masterPUT.StateId;
                audit.AreaId = masterPUT.Id;
                audit.CityId = masterPUT.CityId;
                audit.StatusTypeId = masterPUT.StatusTypeId;
                audit.ActionTypeId = masterPUT.ActionTypeId;
                audit.ExportTypeId = masterPUT.ExportTypeId;
                audit.ExportTo = masterPUT.ExportTo;
                audit.SourceURL = masterPUT.SourceURL;
                audit.IsDefault = masterPUT.IsDefault;
                audit.Browser = masterPUT.Browser;
                audit.DeviceName = masterPUT.DeviceName;
                audit.Location = masterPUT.Location;
                audit.DeviceIP = masterPUT.DeviceIP;
                audit.GoogleMapUrl = masterPUT.GoogleMapUrl;
                audit.Latitude = masterPUT.Latitude;
                audit.Longitude = masterPUT.Longitude;
                audit.ActionBy = masterPUT.UpdatedBy;
                audit.ActionAt = DateTime.Now;

                await context.AreaAudits.AddAsync(audit);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.UpdateSuccess,
                    Data = masterPUT
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = ResponseMessage.RecordExists
                };
            }

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }
}
