using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class CountryService(RapidERPDbContext context, ISharedService shared, IRepository repository) : ICountryService
{
    private RequestResponse _requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<CountryPOSTRequestDTO> masterPOSTs)
    {
        try
        {
            _requestResponse = new();

            foreach (var masterPOST in masterPOSTs)
            {
                var task = CreateSingle(masterPOST);
                var result = await Task.WhenAll(task);
                _requestResponse.Message = result.FirstOrDefault().Message;
                _requestResponse.IsSuccess = result.FirstOrDefault().IsSuccess;
                _requestResponse.StatusCode = result.FirstOrDefault().StatusCode;
                _requestResponse.Data = result.FirstOrDefault().Data;
            }

            return _requestResponse;
        }

        catch
        {
            _requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return _requestResponse;
        }
    }

    public async Task<RequestResponse> CreateSingle(CountryPOSTRequestDTO masterPOST)
    {
        try
        {
            Country masterData = new();
            //await using var transaction = await context.Database.BeginTransactionAsync();
            await using var transaction = await repository.BeginTransactionAsync();
            //var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);
            var masterRecord = await repository.FindById(masterData);

            if (masterRecord is null)
            {
                
                masterData.MenuModuleId = masterPOST.MenuModuleId;
                masterData.TenantId = masterPOST.TenantId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.CurrencyId = masterPOST.CurrencyId;
                masterData.DialCode = masterPOST.DialCode;
                masterData.Name = masterPOST.Name;
                masterData.IsDefault = masterPOST.IsDefault;
                masterData.IsDraft = masterPOST.IsDraft;
                masterData.ISONumeric = masterPOST.ISONumeric;
                masterData.ISO2Code = masterPOST.ISO2Code;
                masterData.ISO3Code = masterPOST.ISO3Code;
                masterData.FlagURL = masterPOST.FlagURL;

                await repository.Add(masterData);

                CountryHistory history = new();
                history.CountryId = masterData.Id;
                history.CurrencyId = masterPOST.CurrencyId;
                history.TenantId = masterPOST.TenantId;
                history.MenuModuleId = masterPOST.MenuModuleId;
                history.ActionTypeId = masterPOST.ActionTypeId;
                history.LanguageId = masterPOST.LanguageId;
                history.ExportTypeId = masterPOST.ExportTypeId;
                history.ExportTo = masterPOST.ExportTo;
                history.SourceURL = masterPOST.SourceURL;
                history.DialCode = masterPOST.DialCode;
                history.Name = masterPOST.Name;
                history.IsDefault = masterPOST.IsDefault;
                history.IsDraft = masterPOST.IsDraft;
                history.ISONumeric = masterPOST.ISONumeric;
                history.ISO2Code = masterPOST.ISO2Code;
                history.ISO3Code = masterPOST.ISO3Code;
                history.FlagURL = masterPOST.FlagURL;
                history.Browser = masterPOST.Browser;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                history.LocationURL = masterPOST.LocationURL;
                history.DeviceName = masterPOST.DeviceName;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                history.ActionBy = masterPOST.ActionBy;
                history.ActionAt = DateTime.Now;

                await repository.Add(history);
                await repository.CommitChanges();
                await transaction.CommitAsync();

                _requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = masterPOST
                };
            }

            else
            {
                _requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = $"{ResponseMessage.RecordExists} {masterPOST.Name}"
                };
            }

            return _requestResponse;
        }

        catch
        {
            _requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return _requestResponse;
        }
    }

    public async Task<RequestResponse> Delete(int id)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            //var ishistoryExists = await context.CountryHistory.AsNoTracking().AnyAsync(x => x.CountryId == id);
            var ishistoryExists = await repository.Set<CountryHistory>().AsNoTracking().AnyAsync(x => x.CountryId == id);

            if (ishistoryExists == false)
            {
                _requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }

            else
            {
                await repository.Set<CountryHistory>().Where(x => x.CountryId == id).ExecuteDeleteAsync();
            }

            //var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Id == id);

            //if (isExists == false)
            //{
            //    _requestResponse = new()
            //    {
            //        StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
            //        IsSuccess = false,
            //        Message = ResponseMessage.NoRecordFound
            //    };
            //}

            //else
            //{
            //    await context.Countries.Where(x => x.Id == id).ExecuteDeleteAsync();
            //    await transaction.CommitAsync();
            //}

            //_requestResponse = new()
            //{
            //    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
            //    IsSuccess = true,
            //    Message = ResponseMessage.DeleteSuccess
            //};
            await shared.Delete<Country>(id);
            return _requestResponse;
        }

        catch (Exception ex)
        {
            _requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _requestResponse;
        }
    }

    public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from c in repository.Set<Country>()
                            //join st in context.StatusTypes on c.StatusTypeId equals st.Id
                        join st in repository.Set<StatusType>() on c.StatusTypeId equals st.Id
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        join l in repository.Set<Language>() on c.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on c.MenuModuleId equals mm.Id
                        join cu in repository.Set<Currency>() on c.CurrencyId equals cu.Id
                        select new GetAllCountriesDTO
                        {
                            Id = c.Id,
                            MenuModule = mm.Name,
                            Tanent = t.Name,
                            Language = l.Name,
                            Status = st.Name,
                            Currency = cu.Name,
                            DialCode = c.DialCode,
                            Country = c.Name,
                            IsDefault =  c.IsDefault,
                            IsDraft = c.IsDraft,
                            ISONumeric = c.ISONumeric,
                            ISO2Code = c.ISO2Code,
                            ISO3Code = c.ISO3Code,
                            FlagURL = c.FlagURL
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Country>(pageSize);
                result.Data = await data.ToListAsync();

                _requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
                };
            }

            else
            {
                result.Count = await shared.GetCounts<Country>(pageSize);
                result.Data = await data.Skip(skip).Take(take).ToListAsync();

                _requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return _requestResponse;
        }

        catch (Exception ex)
        {
            _requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _requestResponse;
        }
    }

    public async Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    {
        try
        {
            var data = (from ca in repository.Set<CountryHistory>()
                        join c in repository.Set<Country>() on ca.CountryId equals c.Id
                        join et in repository.Set<ExportType>() on ca.ExportTypeId equals et.Id
                        join at in repository.Set<ActionType>() on ca.ActionTypeId equals at.Id
                        join t in repository.Set<Tenant>() on ca.TenantId equals t.Id
                        join l in repository.Set<Language>() on ca.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on ca.MenuModuleId equals mm.Id
                        join cu in repository.Set<Currency>() on ca.CurrencyId equals cu.Id
                        select new GetHistoriesDTO
                        {
                            Id = ca.Id,
                            Country = c.Name,
                            Tanent = t.Name,
                            MenuModule = mm.Name,
                            Action = at.Name,
                            Language = l.Name,
                            ExportType = et.Name,
                            Currency = cu.Name,
                            ExportTo = ca.ExportTo,
                            SourceURL = ca.SourceURL,
                            DialCode = ca.DialCode,
                            Name = ca.Name,
                            IsDefault = ca.IsDefault,
                            IsDraft = ca.IsDraft,
                            ISONumeric = ca.ISONumeric,
                            ISO2Code = ca.ISO2Code,
                            ISO3Code = ca.ISO3Code,
                            FlagURL = ca.FlagURL,
                            Browser = ca.Browser,
                            Location = ca.Location,
                            DeviceIP = ca.DeviceIP,
                            LocationURL = ca.LocationURL,
                            DeviceName = ca.DeviceName,
                            Latitude = ca.Latitude,
                            Longitude = ca.Longitude,
                            ActionBy = ca.ActionBy,
                            ActionAt = ca.ActionAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                var result = await data.ToListAsync();

                _requestResponse = new()
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

                _requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return _requestResponse;
        }

        catch (Exception ex)
        {
            _requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _requestResponse;
        }
    }

    public async Task<dynamic> GetSingle(int id)
    {
        var result = await shared.GetSingle<Country>(id);
        return result;
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = await shared.SoftDelete<Country>(id);
        return result;
    }

    public async Task<RequestResponse> Update(CountryPUTRequestDTO masterPUT)
    {
        try
        {
            Country masterData = new();
            CountryHistory history = new();
            await using var transaction = await context.Database.BeginTransactionAsync();
            //var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);
            var masterRecord = await repository.FindById(masterData);
            
            //Loading current data to parameter
            masterPUT.ISONumeric = (masterPUT.ISONumeric is not null) ? masterPUT.ISONumeric : masterRecord.ISONumeric;
            masterPUT.Name = (masterPUT.Name is not null) ? masterPUT.Name : masterRecord.Name;
            masterPUT.ISO2Code = (masterPUT.ISO2Code is not null) ? masterPUT.ISO2Code : masterRecord.ISO2Code;
            masterPUT.ISO3Code = (masterPUT.ISO3Code is not null) ? masterPUT.ISO3Code : masterRecord.ISO3Code;
            masterPUT.MenuModuleId = (masterPUT.MenuModuleId is not null) ? masterPUT.MenuModuleId : masterRecord.MenuModuleId;
            masterPUT.TenantId = (masterPUT.TenantId is not null) ? masterPUT.TenantId : masterRecord.TenantId;
            masterPUT.StatusTypeId = (masterPUT.StatusTypeId != 0) ? masterPUT.StatusTypeId : masterRecord.StatusTypeId;
            masterPUT.LanguageId = (masterPUT.LanguageId is not null) ? masterPUT.LanguageId : masterRecord.LanguageId;
            masterPUT.CurrencyId = (masterPUT.CurrencyId != 0) ? masterPUT.CurrencyId : masterRecord.CurrencyId;
            masterPUT.DialCode = (masterPUT.DialCode is not null) ? masterPUT.DialCode : masterRecord.DialCode;
            masterPUT.FlagURL = (masterPUT.FlagURL is not null) ? masterPUT.FlagURL : masterRecord.FlagURL;
            
             

            if (masterRecord is null)
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

                
                masterData.MenuModuleId = masterPUT.MenuModuleId;
                masterData.TenantId = masterPUT.TenantId;
                masterData.StatusTypeId = masterPUT.StatusTypeId;
                masterData.LanguageId = masterPUT.LanguageId;
                masterData.CurrencyId = masterPUT.CurrencyId;
                masterData.DialCode = masterPUT.DialCode;
                masterData.Name = masterPUT.Name;
                masterData.IsDefault = masterPUT.IsDefault;
                masterData.IsDraft = masterPUT.IsDraft;
                masterData.ISONumeric = masterPUT.ISONumeric;
                masterData.ISO2Code = masterPUT.ISO2Code;
                masterData.ISO3Code = masterPUT.ISO3Code;
                masterData.FlagURL = masterPUT.FlagURL;

                await repository.Update(masterData);

                history.CountryId = masterPUT.Id;
                history.TenantId = masterPUT.TenantId;
                history.MenuModuleId = masterPUT.MenuModuleId;
                history.ActionTypeId = masterPUT.ActionTypeId;
                history.LanguageId = masterPUT.LanguageId;
                history.CurrencyId = masterPUT.CurrencyId;
                history.ExportTypeId = masterPUT.ExportTypeId;
                history.ExportTo = masterPUT.ExportTo;
                history.SourceURL = masterPUT.SourceURL;
                history.DialCode = masterPUT.DialCode;
                history.Name = masterPUT.Name;
                history.IsDefault = masterPUT.IsDefault;
                history.IsDraft = masterPUT.IsDraft;
                history.ISONumeric = masterPUT.ISONumeric;
                history.ISO2Code = masterPUT.ISO2Code;
                history.ISO3Code = masterPUT.ISO3Code;
                history.FlagURL = masterPUT.FlagURL;
                history.Browser = masterPUT.Browser;
                history.Location = masterPUT.Location;
                history.DeviceIP = masterPUT.DeviceIP;
                history.LocationURL = masterPUT.LocationURL;
                history.DeviceName = masterPUT.DeviceName;
                history.Latitude = masterPUT.Latitude;
                history.Longitude = masterPUT.Longitude;
                history.ActionBy = masterPUT.ActionBy;
                history.ActionAt = DateTime.Now;
                
                await repository.Add(history);
                await repository.CommitChanges();
                await transaction.CommitAsync();


                _requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.UpdateSuccess,
                    Data = masterPUT
                };
            }

            else
            {
                _requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = ResponseMessage.RecordExists
                };
            }

            return _requestResponse;
        }

        catch
        {
            _requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return _requestResponse;
        }
    }
}
