using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.LanguageDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
#nullable enable
public class LanguageService(RapidERPDbContext context) : ILanguage
{
    RequestResponse? requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<LanguagePOST> masterPOSTs)
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

     

    public async Task<RequestResponse> CreateSingle(LanguagePOST masterPOST)
    {
        try
        {
            var isExists = await context.Languages.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name || x.ISONumeric == masterPOST.ISONumeric || x.ISO2Code == masterPOST.ISO2Code || x.ISO3Code == masterPOST.ISO3Code || x.Icon == masterPOST.Icon);

            if (isExists == false)
            {
                Language masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.ISONumeric = masterPOST.ISONumeric;
                masterData.ISO2Code = masterPOST.ISO2Code;
                masterData.ISO3Code = masterPOST.ISO3Code;
                masterData.Icon = masterPOST.Icon;
                masterData.CreatedBy = masterPOST.CreatedBy;
                masterData.CreatedAt = DateTime.Now;

                await context.Languages.AddAsync(masterData);
                await context.SaveChangesAsync();

                LanguageAudit audit = new();
                audit.LanguageId = masterData.Id;
                audit.Name = masterPOST.Name;
                audit.ISONumeric = masterPOST.ISONumeric;
                audit.ISO2Code = masterPOST.ISO2Code;
                audit.ISO3Code = masterPOST.ISO3Code;
                audit.Icon = masterPOST.Icon;

                await context.LanguageAudits.AddAsync(audit);
                await context.SaveChangesAsync();

                LanguageTracker tracker = new();
                tracker.LanguageId = masterData.Id;
                tracker.Browser = masterPOST.Browser;
                tracker.Location = masterPOST.Location;
                tracker.DeviceIP = masterPOST.DeviceIP;
                tracker.GoogleMapUrl = masterPOST.GoogleMapUrl;
                tracker.DeviceName = masterPOST.DeviceName;
                tracker.Latitude = masterPOST.Latitude;
                tracker.Longitude = masterPOST.Longitude;
                tracker.ActionBy = masterPOST.CreatedBy;
                tracker.ActionAt = DateTime.Now;

                await context.LanguageTrackers.AddAsync(tracker);
                await context.SaveChangesAsync();

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
            var isExists = await context.Languages.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.Languages.Where(x => x.Id == id).ExecuteDeleteAsync();
            }

            var isAuditExists = await context.LanguageAudits.AsNoTracking().AnyAsync(x => x.LanguageId == id);

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
                await context.LanguageAudits.Where(x => x.LanguageId == id).ExecuteDeleteAsync();
            }

            var isTrackerExists = await context.LanguageTrackers.AsNoTracking().AnyAsync(x => x.LanguageId == id);
            
            if (isTrackerExists == false)
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
                await context.LanguageTrackers.Where(x => x.LanguageId == id).ExecuteDeleteAsync();
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
            //var data = context.Languages.AsNoTracking().AsQueryable();
            var data = (from l in context.Languages
                        join lt in context.LanguageTrackers on l.Id equals lt.LanguageId
                        select new
                        {
                            l.Id,
                            l.Name,
                            l.ISO2Code,
                            l.ISO3Code,
                            l.ISONumeric,
                            l.Icon,
                            lt.Browser,
                            lt.DeviceIP,
                            lt.DeviceName,
                            lt.Location,
                            lt.GoogleMapUrl,
                            lt.Latitude,
                            lt.Longitude,
                            lt.ActionBy,
                            lt.ActionAt
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
            var data = context.LanguageAudits
                .Select(x => new { x.ISO2Code, x.ISO3Code, x.ISONumeric, x.Icon, x.Name, Language = x.Language.Name })
                .AsNoTracking().AsQueryable();

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

    public async Task<RequestResponse> GetAllExports(int skip, int take)
    {
        try
        {
            var data = context.Languages
                .AsNoTracking().AsQueryable();

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
            var data = await context.Languages.Where(x => x.Id == id).AsNoTracking().ToListAsync();

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
     
    public async Task<RequestResponse> Update(LanguagePUT masterPUT)
    {
        try
        {
            var isExists = await context.Languages.AsNoTracking().AnyAsync(x => (x.Name == masterPUT.Name || x.ISONumeric == masterPUT.ISONumeric || x.ISO2Code == masterPUT.ISO2Code || x.ISO3Code == masterPUT.ISO3Code || x.Icon == masterPUT.Icon) && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Languages.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.ISO2Code, masterPUT.ISO2Code)
                .SetProperty(x => x.ISO3Code, masterPUT.ISO3Code)
                .SetProperty(x => x.ISONumeric, masterPUT.ISONumeric)
                .SetProperty(x => x.Icon, masterPUT.Icon)
                .SetProperty(x => x.UpdatedBy, masterPUT.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, DateTime.Now));
                
                LanguageAudit audit = new();
                audit.LanguageId = masterPUT.Id;
                audit.Name = masterPUT.Name;
                audit.ISO2Code = masterPUT.ISO2Code;
                audit.ISO3Code = masterPUT.ISO3Code;
                audit.ISONumeric = masterPUT.ISONumeric;
                audit.Icon = masterPUT.Icon;

                await context.LanguageAudits.AddAsync(audit);
                await context.SaveChangesAsync();

                LanguageTracker tracker = new();
                tracker.LanguageId = masterPUT.Id;              
                tracker.Browser = masterPUT.Browser;
                tracker.Location = masterPUT.Location;
                tracker.DeviceIP = masterPUT.DeviceIP;
                tracker.GoogleMapUrl = masterPUT.GoogleMapUrl;
                tracker.DeviceName = masterPUT.DeviceName;
                tracker.Latitude = masterPUT.Latitude;
                tracker.Longitude = masterPUT.Longitude;
                tracker.ActionBy = masterPUT.UpdatedBy;
                tracker.ActionAt = DateTime.Now;

                await context.LanguageTrackers.AddAsync(tracker);
                await context.SaveChangesAsync();

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
