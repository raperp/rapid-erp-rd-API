using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.LanguageDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class LanguageService(RapidERPDbContext context, IShared shared) : ILanguage
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<LanguagePOST> masterPOSTs)
    {
        try
        {
            requestResponse = new();

            foreach (var masterPOST in masterPOSTs)
            {
                var task = CreateSingle(masterPOST);
                var result = await Task.WhenAll(task);
                requestResponse.Message = result.FirstOrDefault().Message;
                requestResponse.IsSuccess = result.FirstOrDefault().IsSuccess;
                requestResponse.StatusCode = result.FirstOrDefault().StatusCode;
                requestResponse.Data = result.FirstOrDefault().Data;
            }

            //requestResponse = new()
            //{
            //    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
            //    IsSuccess = true,
            //    Message = req.Message,
            //    Data = req.Data
            //};

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
            await using var transaction = await context.Database.BeginTransactionAsync();
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

                await context.LanguageAudits.AddAsync(audit);
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
                    Message = $"{ResponseMessage.RecordExists} {masterPOST.Name}"
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
            var data = context.Languages.Select(x => new { x.Id, x.Name, x.ISONumeric, x.ISO2Code, x.ISO3Code, x.Icon, x.CreatedAt, x.CreatedBy }).AsNoTracking().AsQueryable();
            
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
            var data = (from la in context.LanguageAudits
                        join l in context.Languages on la.LanguageId equals l.Id
                        //join et in context.ExportTypes on la.ExportTypeId equals et.Id
                        select new
                        {
                            la.Id,
                            Language = l.Name,
                            la.Name,
                            la.ISONumeric,
                            la.ISO2Code,
                            la.ISO3Code,
                            la.Icon,
                            //ExportType = et.Name,
                            la.Browser,
                            la.Location,
                            la.DeviceIP,
                            la.GoogleMapUrl,
                            la.DeviceName,
                            la.Latitude,
                            la.Longitude,
                            la.ActionBy,
                            la.ActionAt
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

    public async Task<dynamic> GetSingle(int id)
    {
        var result = await shared.GetSingle<Language>(id);
        return result;
    }
     
    public async Task<RequestResponse> Update(LanguagePUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Languages.AsNoTracking().AnyAsync(x => (x.Name == masterPUT.Name || x.ISONumeric == masterPUT.ISONumeric || x.ISO2Code == masterPUT.ISO2Code || x.ISO3Code == masterPUT.ISO3Code || x.Icon == masterPUT.Icon) && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Languages.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.ISONumeric, masterPUT.ISONumeric)
                .SetProperty(x => x.ISO2Code, masterPUT.ISO2Code)
                .SetProperty(x => x.ISO3Code, masterPUT.ISO3Code)
                .SetProperty(x => x.Icon, masterPUT.Icon)
                .SetProperty(x => x.UpdatedBy, masterPUT.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, DateTime.Now));

                LanguageAudit audit = new();
                audit.LanguageId = masterPUT.Id;
                audit.Name = masterPUT.Name;
                audit.ISONumeric = masterPUT.ISONumeric;
                audit.ISO2Code = masterPUT.ISO2Code;
                audit.ISO3Code = masterPUT.ISO3Code;
                audit.Icon = masterPUT.Icon;
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

                await context.LanguageAudits.AddAsync(audit);
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
