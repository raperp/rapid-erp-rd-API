using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services.CountryServices;

public class CountryBService(IRepository repository) : ICountryBService
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> CreateBulk(List<CountryPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(CountryPOST masterPOST)
    {
        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<Country>(masterPOST.Name);

            if (isExists == false)
            {
                Country masterData = new();
                masterData.MenuModuleId = masterPOST.MenuModuleId;
                masterData.TenantId = masterPOST.TenantId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                //masterData.LanguageId = masterPOST.LanguageId;
                //masterData.CurrencyId = masterPOST.CurrencyId;
                masterData.DialCode = masterPOST.DialCode;
                masterData.Name = masterPOST.Name;
                masterData.IsDefault = masterPOST.IsDefault;
                masterData.IsDraft = masterPOST.IsDraft;
                masterData.ISONumeric = masterPOST.ISONumeric;
                masterData.ISO2Code = masterPOST.ISO2Code;
                masterData.ISO3Code = masterPOST.ISO3Code;
                masterData.FlagURL = masterPOST.FlagURL;
                masterData.RegionId = masterPOST.RegionId;
                masterData.StateId = masterPOST.StateId;
                masterData.TimeZoneId = masterPOST.TimeZoneId;

                await repository.Add(masterData);

                CountryAudit audit = new();
                audit.CountryId = masterData.Id;
                //history.CurrencyId = masterPOST.CurrencyId;
                audit.TenantId = masterPOST.TenantId;
                audit.MenuModuleId = masterPOST.MenuModuleId;
                audit.ActionTypeId = masterPOST.ActionTypeId;
                //history.LanguageId = masterPOST.LanguageId;
                //audit.ExportTypeId = masterPOST.ExportTypeId;
                //audit.ExportTo = masterPOST.ExportTo;
                //audit.SourceURL = masterPOST.SourceURL;
                audit.DialCode = masterPOST.DialCode;
                audit.Name = masterPOST.Name;
                audit.IsDefault = masterPOST.IsDefault;
                audit.IsDraft = masterPOST.IsDraft;
                audit.ISONumeric = masterPOST.ISONumeric;
                audit.ISO2Code = masterPOST.ISO2Code;
                audit.ISO3Code = masterPOST.ISO3Code;
                audit.FlagURL = masterPOST.FlagURL;
                audit.RegionId = masterPOST.RegionId;
                audit.StateId = masterPOST.StateId;
                audit.TimeZoneId = masterPOST.TimeZoneId;
                //history.Browser = masterPOST.Browser;
                //history.Location = masterPOST.Location;
                //history.DeviceIP = masterPOST.DeviceIP;
                //history.LocationURL = masterPOST.LocationURL;
                //history.DeviceName = masterPOST.DeviceName;
                //history.Latitude = masterPOST.Latitude;
                //history.Longitude = masterPOST.Longitude;
                audit.ActionBy = masterPOST.ActionBy;
                audit.ActionAt = DateTime.Now;

                await repository.Add(audit);

                //CountryActivity activity = new();
                //activity.CountryId = masterData.Id;
                //activity.PageViewStartedAt = masterPOST.PageViewStartedAt;
                //activity.PageViewEndedAt = masterPOST.PageViewEndedAt; 
                //activity.Browser = masterPOST.Browser;
                //activity.Location = masterPOST.Location;
                //activity.LocationURL = masterPOST.LocationURL;
                //activity.DeviceIP = masterPOST.DeviceIP;
                //activity.DeviceName = masterPOST.DeviceName;
                //activity.OS = masterPOST.OS;
                //activity.Latitude = masterPOST.Latitude;
                //activity.Longitude = masterPOST.Longitude;
                //activity.ActionTypeId = masterPOST.ActionTypeId;
                //activity.ActivityTypeId = masterPOST.ActivityTypeId;
                //activity.ActionBy = masterPOST.ActionBy;
                //activity.ActionAt = DateTime.UtcNow;

                //await repository.Add(activity);
                transaction.Commit();

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
            if (id is not 0)
            {
                var histories = await repository.Set<CountryAudit>().Where(c => c.CountryId == id).Select(x => x.Id).ToListAsync();

                foreach (var item in histories)
                {
                    await repository.Delete<CountryAudit>(item);
                }

                await repository.Delete<Country>(id);

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.DeleteSuccess
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };
        }

        return requestResponse;
    }

    public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from c in repository.Set<Country>()
                        join st in repository.Set<StatusType>() on c.StatusTypeId equals st.Id
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        //join l in repository.Set<Language>() on c.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on c.MenuModuleId equals mm.Id
                        //join cu in repository.Set<Currency>() on c.CurrencyId equals cu.Id
                        select new
                        {
                            c.Id,
                            MenuModule = mm.Name,
                            Tanent = t.Name,
                            //Language = l.Name,
                            Status = st.Name,
                            //Currency = cu.Name,
                            c.DialCode,
                            c.Name,
                            c.IsDefault,
                            c.IsDraft,
                            c.ISONumeric,
                            c.ISO2Code,
                            c.ISO3Code,
                            c.FlagURL
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                //result.Count = await repository.GetCounts<Country>(query.pageSize);
                result.Data = await data.ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result.Data
                };
            }

            else
            {
                //result.Count = await repository.GetCounts<Country>(query.pageSize);
                result.Data = await data.Skip(skip).Take(take).ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result.Data
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

    public async Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    {
        try
        {
            GetHistoryDTO result = new();

            var data = (from ch in repository.Set<CountryAudit>()
                        join c in repository.Set<Country>() on ch.CountryId equals c.Id
                        //join et in repository.Set<ExportType>() on ca.ExportTypeId equals et.Id
                        join at in repository.Set<ActionType>() on ch.ActionTypeId equals at.Id
                        join t in repository.Set<Tenant>() on ch.TenantId equals t.Id
                        //join l in repository.Set<Language>() on ch.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on ch.MenuModuleId equals mm.Id
                        //join cu in repository.Set<Currency>() on ch.CurrencyId equals cu.Id
                        select new
                        {
                            ch.Id,
                            Country = c.Name,
                            Tanent = t.Name,
                            MenuModule = mm.Name,
                            Action = at.Name,
                            //Language = l.Name,
                            //ExportType = et.Name,
                            //Currency = cu.Name,
                            //ch.ExportTo,
                            //ch.SourceURL,
                            ch.DialCode,
                            ch.Name,
                            ch.IsDefault,
                            ch.IsDraft,
                            ch.ISONumeric,
                            ch.ISO2Code,
                            ch.ISO3Code,
                            ch.FlagURL,
                            //ch.Browser,
                            //ch.Location,
                            //ch.DeviceIP,
                            //ch.LocationURL,
                            //ch.DeviceName,
                            //ch.Latitude,
                            //ch.Longitude,
                            ch.ActionBy,
                            ch.ActionAt
                        }).AsNoTracking().AsQueryable();

            //int totalItems = await repository.Set<CountryHistory>().CountAsync();
            //int totalPages = (totalItems + query.pageSize - 1) / query.pageSize;

            if (skip == 0 || take == 0)
            {
                //result.TotalCount = totalItems;
                //result.TotalPages = totalPages;
                result.Data = await data.ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result.Data
                };
            }

            else
            {
                //result.TotalCount = totalItems;
                //result.TotalPages = totalPages;
                result.Data = await data.Skip(skip).Take(take).ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result.Data
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
            var data = (from c in repository.Set<Country>()
                        join st in repository.Set<StatusType>() on c.StatusTypeId equals st.Id
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        //join l in repository.Set<Language>() on c.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on c.MenuModuleId equals mm.Id
                        //join cu in repository.Set<Currency>() on c.CurrencyId equals cu.Id
                        select new
                        {
                            c.Id,
                            MenuModule = mm.Name,
                            Tanent = t.Name,
                            //Language = l.Name,
                            Status = st.Name,
                            //Currency = cu.Name,
                            c.DialCode,
                            Country = c.Name,
                            c.IsDefault,
                            c.IsDraft,
                            c.ISONumeric,
                            c.ISO2Code,
                            c.ISO3Code,
                            c.FlagURL
                        }).AsNoTracking().AsQueryable();

            var result = await data.Where(x => x.Id == id).ToListAsync();

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = result.FirstOrDefault()
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

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> SoftDelete(int id)
    {
        try
        {
            var result = await repository.SoftDelete<Country>(id);

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.UpdateSuccess,
                Data = result
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

    public async Task<RequestResponse> Update(CountryPUT masterPUT)
    {
        try
        {
            //Country masterData = new();
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<Country>(masterPUT.Id, masterPUT.Name);
            var masterRecord = await repository.FindById<Country>(masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                masterPUT.ISONumeric = (masterPUT.ISONumeric is not null) ? masterPUT.ISONumeric : masterRecord.ISONumeric;
                masterPUT.Name = (masterPUT.Name is not null) ? masterPUT.Name : masterRecord.Name;
                masterPUT.ISO2Code = (masterPUT.ISO2Code is not null) ? masterPUT.ISO2Code : masterRecord.ISO2Code;
                masterPUT.ISO3Code = (masterPUT.ISO3Code is not null) ? masterPUT.ISO3Code : masterRecord.ISO3Code;
                masterPUT.MenuModuleId = (masterPUT.MenuModuleId is not null) ? masterPUT.MenuModuleId : masterRecord.MenuModuleId;
                masterPUT.TenantId = (masterPUT.TenantId is not null) ? masterPUT.TenantId : masterRecord.TenantId;
                masterPUT.StatusTypeId = (masterPUT.StatusTypeId is not null) ? masterPUT.StatusTypeId : masterRecord.StatusTypeId;
                //masterPUT.LanguageId = (masterPUT.LanguageId is not null) ? masterPUT.LanguageId : masterRecord.LanguageId;
                //masterPUT.CurrencyId = (masterPUT.CurrencyId is not null) ? masterPUT.CurrencyId : masterRecord.CurrencyId;
                masterPUT.DialCode = (masterPUT.DialCode is not null) ? masterPUT.DialCode : masterRecord.DialCode;
                masterPUT.FlagURL = (masterPUT.FlagURL is not null) ? masterPUT.FlagURL : masterRecord.FlagURL;
                masterPUT.RegionId = (masterPUT.RegionId != 0) ? masterPUT.RegionId : masterRecord.RegionId;
                masterPUT.StateId = (masterPUT.StateId != 0) ? masterPUT.StateId : masterRecord.StateId;
                masterPUT.TimeZoneId = (masterPUT.TimeZoneId != 0) ? masterPUT.TimeZoneId : masterRecord.TimeZoneId;
            }

            if (isExists == false)
            {
                //await context.Countries.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                //.SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                //.SetProperty(x => x.TenantId, masterPUT.TenantId)
                //.SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                //.SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                //.SetProperty(x => x.CurrencyId, masterPUT.CurrencyId)
                //.SetProperty(x => x.DialCode, masterPUT.DialCode)
                //.SetProperty(x => x.Name, masterPUT.Name)
                //.SetProperty(x => x.IsDefault, masterPUT.IsDefault)
                //.SetProperty(x => x.IsDraft, masterPUT.IsDraft)
                //.SetProperty(x => x.ISONumeric, masterPUT.ISONumeric)
                //.SetProperty(x => x.ISO2Code, masterPUT.ISO2Code)
                //.SetProperty(x => x.ISO3Code, masterPUT.ISO3Code)
                //.SetProperty(x => x.FlagURL, masterPUT.FlagURL));

                masterRecord.MenuModuleId = masterPUT.MenuModuleId;
                masterRecord.TenantId = masterPUT.TenantId;
                masterRecord.StatusTypeId = masterPUT.StatusTypeId;
                //masterRecord.LanguageId = masterPUT.LanguageId;
                //masterRecord.CurrencyId = masterPUT.CurrencyId;
                masterRecord.DialCode = masterPUT.DialCode;
                masterRecord.Name = masterPUT.Name;
                masterRecord.IsDefault = masterPUT.IsDefault;
                masterRecord.IsDraft = masterPUT.IsDraft;
                masterRecord.ISONumeric = masterPUT.ISONumeric;
                masterRecord.ISO2Code = masterPUT.ISO2Code;
                masterRecord.ISO3Code = masterPUT.ISO3Code;
                masterRecord.FlagURL = masterPUT.FlagURL;
                masterRecord.RegionId = masterPUT.RegionId;
                masterRecord.StateId = masterPUT.StateId;
                masterRecord.TimeZoneId = masterPUT.TimeZoneId;

                await repository.Update(masterRecord);

                CountryAudit history = new();
                history.CountryId = masterPUT.Id;
                //history.CurrencyId = masterPUT.CurrencyId;
                history.TenantId = masterPUT.TenantId;
                history.MenuModuleId = masterPUT.MenuModuleId;
                history.ActionTypeId = masterPUT.ActionTypeId;
                //history.LanguageId = masterPUT.LanguageId;
                //history.ExportTypeId = masterPUT.ExportTypeId;
                //history.ExportTo = masterPUT.ExportTo;
                //history.SourceURL = masterPUT.SourceURL;
                history.DialCode = masterPUT.DialCode;
                history.Name = masterPUT.Name;
                history.IsDefault = masterPUT.IsDefault;
                history.IsDraft = masterPUT.IsDraft;
                history.ISONumeric = masterPUT.ISONumeric;
                history.ISO2Code = masterPUT.ISO2Code;
                history.ISO3Code = masterPUT.ISO3Code;
                history.RegionId = masterPUT.RegionId;
                history.StateId = masterPUT.StateId;
                history.TimeZoneId = masterPUT.TimeZoneId;
                history.FlagURL = masterPUT.FlagURL;
                //history.Browser = masterPUT.Browser;
                //history.Location = masterPUT.Location;
                //history.DeviceIP = masterPUT.DeviceIP;
                //history.LocationURL = masterPUT.LocationURL;
                //history.DeviceName = masterPUT.DeviceName;
                //history.Latitude = masterPUT.Latitude;
                //history.Longitude = masterPUT.Longitude;
                history.ActionBy = masterPUT.ActionBy;
                history.ActionAt = DateTime.Now;

                await repository.Add(history);
                transaction.Commit();

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
