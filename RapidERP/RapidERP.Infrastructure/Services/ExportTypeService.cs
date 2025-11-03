using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.ExportTypeDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class ExportTypeService(RapidERPDbContextConfig configContext, RapidERPDbContextRead readContext, RapidERPDbContextWrite writeContext) : IExportType
{
    RequestResponse? requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<ExportTypePOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(ExportTypePOST masterPOST)
    {
        try
        {
            var isExists = await configContext.ExportTypes.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                ExportType masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.Description = masterPOST.Description;
                masterData.CreatedBy = masterPOST.CreatedBy;
                masterData.CreatedAt = DateTime.Now;

                await configContext.ExportTypes.AddAsync(masterData);
                await configContext.SaveChangesAsync();

                ExportTypeAudit audit = new();
                audit.Name = masterData.Name;
                audit.Description = masterPOST.Description;
                audit.ExportTypeId = masterData.Id;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.IsDefault = masterPOST.IsDefault;
                audit.Browser = masterPOST.Browser;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                audit.GoogleMapUrl = masterPOST.GoogleMapUrl;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                audit.ActionBy = masterPOST.CreatedBy;
                audit.ActionAt = DateTime.Now;

                await writeContext.ExportTypeAudits.AddAsync(audit);
                await writeContext.SaveChangesAsync();

                ExportTypeTracker tracker = new();
                audit.Name = masterData.Name;
                audit.Description = masterPOST.Description;
                audit.ExportTypeId = masterData.Id;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.IsDefault = masterPOST.IsDefault;
                audit.Browser = masterPOST.Browser;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                audit.GoogleMapUrl = masterPOST.GoogleMapUrl;
                audit.ActionBy = masterPOST.CreatedBy;
                audit.ActionAt = DateTime.Now;

                await readContext.ExportTypeTrackers.AddAsync(tracker);
                await readContext.SaveChangesAsync();

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
            var isExists = await configContext.ExportTypes.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await configContext.ExportTypes.Where(x => x.Id == id).ExecuteDeleteAsync();
            }

            var isAuditExists = await writeContext.ExportTypeAudits.AsNoTracking().AnyAsync(x => x.ExportTypeId == id);

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
                await writeContext.ExportTypeAudits.Where(x => x.ExportTypeId == id).ExecuteDeleteAsync();
            }

            var isTrackerExists = await readContext.ExportTypeTrackers.AsNoTracking().AnyAsync(x => x.ExportTypeId == id);

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
                await readContext.ExportTypeTrackers.Where(x => x.ExportTypeId == id).ExecuteDeleteAsync();
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
            //var data = context.ExportTypes.AsNoTracking().AsQueryable();
            var data = (from et in readContext.ExportTypes
                              join ett in readContext.ExportTypeTrackers on et.Id equals ett.ExportTypeId
                              select new
                              {
                                  et.Id,
                                  et.Name,
                                  et.Description,
                                  et.CreatedBy,
                                  et.CreatedAt,
                                  et.UpdatedBy,
                                  et.UpdatedAt,
                                  ett.Browser,
                                  ett.Location,
                                  ett.DeviceIP,
                                  ett.GoogleMapUrl,
                                  ett.DeviceName,
                                  ett.Latitude,
                                  ett.Longitude,
                                  ett.ActionAt,
                                  ett.ActionBy
                              }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                var result = await data.ToListAsync() ;

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
            var data = writeContext.ExportTypeAudits
                .Select(x => new { x.Name, x.Description, ExportType = x.ExportType.Name })
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
            var data = await configContext.ExportTypes.Where(x => x.Id == id).AsNoTracking().ToListAsync();

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

    public async Task<RequestResponse> Update(ExportTypePUT masterPUT)
    {
        try
        {
            var isExists = await configContext.ExportTypes.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await configContext.ExportTypes.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.Description, masterPUT.Description)
                .SetProperty(x => x.UpdatedBy, masterPUT.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, DateTime.Now));

                ExportTypeAudit audit = new();
                audit.ExportTypeId = masterPUT.Id;
                audit.Name = masterPUT.Name;
                audit.Description = masterPUT.Description;

                await writeContext.ExportTypeAudits.AddAsync(audit);
                await writeContext.SaveChangesAsync();

                ExportTypeTracker tracker = new();
                tracker.ExportTypeId = masterPUT.Id;
                tracker.Browser = masterPUT.Browser;
                tracker.Location = masterPUT.Location;
                tracker.DeviceIP = masterPUT.DeviceIP;
                tracker.GoogleMapUrl = masterPUT.GoogleMapUrl;
                tracker.DeviceName = masterPUT.DeviceName;
                tracker.Latitude = masterPUT.Latitude;
                tracker.Longitude = masterPUT.Longitude;
                tracker.ActionBy = masterPUT.UpdatedBy;
                tracker.ActionAt = DateTime.Now;

                await readContext.ExportTypeTrackers.AddAsync(tracker);
                await readContext.SaveChangesAsync();

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
