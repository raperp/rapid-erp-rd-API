using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using System.Data;
using UpdateStatus = RapidERP.Application.DTOs.Shared.UpdateStatus;

namespace RapidERP.Infrastructure.Services.CountryServices;

public class CountryService(IRepository repository) : ICountryService
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Create(CountryPOST masterPOST)
    {
        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<Country>(masterPOST.Name);

            ActionDTO actionDTO = new();
            actionDTO.CreatedAt = (masterPOST.IsDraft == false) ? DateTime.UtcNow : null; 
            actionDTO.DraftedAt = (masterPOST.IsDraft == true) ? DateTime.UtcNow : null; 
            actionDTO.UpdatedAt = null; 
            actionDTO.DeletedAt = null;

            if (isExists == false)
            {
                Country masterData = new();
                masterData.TenantId = masterPOST.TenantId;
                masterData.DefaultLanguageId = masterPOST.DefaultLanguageId;
                masterData.DefaultCurrencyId = masterPOST.DefaultCurrencyId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.Name = masterPOST.Name;
                masterData.Code = masterPOST.Code;
                masterData.IsDefault = masterPOST.IsDefault;
                masterData.ISONumeric = masterPOST.ISONumeric;
                masterData.ISO2Code = masterPOST.ISO2Code;
                masterData.ISO3Code = masterPOST.ISO3Code;
                masterData.FlagURL = masterPOST.FlagURL;
                masterData.CreatedAt = actionDTO.CreatedAt;
                masterData.DraftedAt = actionDTO.DraftedAt;
                masterData.UpdatedAt = actionDTO.UpdatedAt;
                masterData.DeletedAt = actionDTO.DeletedAt;

                await repository.Add(masterData);

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
                var localizations = await repository.Set<CountryLocalization>().Where(c => c.CountryId == id).Select(x => x.Id).ToListAsync();
                var currencies  = await repository.Set<CountryCurrency>().Where(c => c.CountryId == id).Select(x => x.Id).ToListAsync();

                foreach (var item in localizations)
                {
                    await repository.Delete<CountryLocalization>(item);
                }

                foreach (var item in currencies)
                {
                    await repository.Delete<CountryCurrency>(item);
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
            GetAllDTO result = new();

            var data = (from c in repository.Set<Country>()
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        select new
                        {
                            c.Id,
                            Tanent = t.Name,
                            c.Name,
                            c.Code,
                            c.IsDefault,
                            c.IsDraft,
                            //c.IsActive,
                            //c.IsDeleted,
                            c.ISONumeric,
                            c.ISO2Code,
                            c.ISO3Code,
                            c.FlagURL,
                            c.CreatedAt,
                            c.DraftedAt,
                            c.UpdatedAt,
                            c.DeletedAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await repository.GetCounts<Country>();
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
                result.Count = await repository.GetCounts<Country>();
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

    public async Task<RequestResponse> GetById(int id)
    {
        try
        {
            var data = (from c in repository.Set<Country>()
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        select new
                        {
                            c.Id,
                            Tanent = t.Name,
                            c.Name,
                            c.Code,
                            c.IsDefault,
                            c.IsDraft,
                            //c.IsActive,
                            //c.IsDeleted,
                            c.ISONumeric,
                            c.ISO2Code,
                            c.ISO3Code,
                            c.FlagURL,
                            c.CreatedAt,
                            c.DraftedAt,
                            c.UpdatedAt,
                            c.DeletedAt
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

    public async Task<RequestResponse> Restore(int id)
    {
        try
        {
            var result = await repository.Restore<Country>(id);

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

    public async Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus)
    {
        try
        {
            var result = await repository.UpdateStatus<Country>(updateStatus);

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
            //using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<Country>(masterPUT.Id, masterPUT.Name);
            var masterRecord = await repository.FindById<Country>(masterPUT.Id);

            //var localizations = await repository.Set<CountryLocalization>().Where(c => c.CountryId == masterPUT.Id).ToListAsync();
            //var currencies = await repository.Set<CountryCurrency>().Where(c => c.CountryId == masterPUT.Id).ToListAsync();
             
            //foreach (var localization in localizations)
            //{
            //    localization.Name = masterPUT.Name;
            //    localization.CountryId = masterPUT.Id;
            //    localization.LanguageId = masterPUT.LanguageId;

            //    await repository.Update(localization);
            //}

            //foreach (var currency in currencies)
            //{
            //    currency.CountryId = masterPUT.Id;
            //    currency.CurrencyId = masterPUT.CurrencyId;

            //    await repository.Update(currency);
            //}

            ActionDTO actionDTO = new();
            actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.UtcNow : null;
            actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.UtcNow : null;

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                masterPUT.ISONumeric = (masterPUT.ISONumeric is not null) ? masterPUT.ISONumeric : masterRecord.ISONumeric;
                masterPUT.ISO2Code = (masterPUT.ISO2Code is not null) ? masterPUT.ISO2Code : masterRecord.ISO2Code;
                masterPUT.ISO3Code = (masterPUT.ISO3Code is not null) ? masterPUT.ISO3Code : masterRecord.ISO3Code;
                masterPUT.Name = (masterPUT.Name is not null) ? masterPUT.Name : masterRecord.Name;
                masterPUT.Code = (masterPUT.Code is not null) ? masterPUT.Code : masterRecord.Code;
                masterPUT.FlagURL = (masterPUT.FlagURL is not null) ? masterPUT.FlagURL : masterRecord.FlagURL;
                masterPUT.TenantId = (masterPUT.TenantId is not null) ? masterPUT.TenantId : masterRecord.TenantId;
                masterPUT.IsDefault = (masterPUT.IsDefault is not null) ? masterPUT.IsDefault : masterRecord.IsDefault;
                masterPUT.IsDraft = (masterPUT.IsDraft is not null) ? masterPUT.IsDraft : masterRecord.IsDraft;
                //masterPUT.IsActive = (masterPUT.IsActive is not null) ? masterPUT.IsActive : masterRecord.IsActive;
                //masterPUT.IsDeleted = (masterPUT.IsDeleted is not null) ? masterPUT.IsDeleted : masterRecord.IsDeleted;
            }

            if (isExists == false)
            {
                masterRecord.TenantId = masterPUT.TenantId;
                masterRecord.DefaultLanguageId = masterPUT.DefaultLanguageId;
                masterRecord.DefaultCurrencyId = masterPUT.DefaultCurrencyId;
                masterRecord.StatusTypeId = masterPUT.StatusTypeId;
                masterRecord.Code = masterPUT.Code;
                masterRecord.Name = masterPUT.Name;
                masterRecord.IsDefault = masterPUT.IsDefault;   
                masterRecord.ISONumeric = masterPUT.ISONumeric;
                masterRecord.ISO2Code = masterPUT.ISO2Code;
                masterRecord.ISO3Code = masterPUT.ISO3Code;
                masterRecord.FlagURL = masterPUT.FlagURL;
                masterRecord.DraftedAt = actionDTO.DraftedAt;
                masterRecord.UpdatedAt = actionDTO.UpdatedAt;

                await repository.Update(masterRecord);

                //CountryAudit audit = new();
                //audit.CountryId = masterPUT.Id;
                //audit.CurrencyId = masterPUT.CurrencyId;
                //audit.StatusTypeId = masterPUT.StatusTypeId;
                //audit.ActionTypeId = masterPUT.ActionTypeId;
                //audit.LanguageId = masterPUT.LanguageId;
                //audit.Code = masterPUT.Code;
                //audit.Name = masterPUT.Name;
                //audit.IsDefault = masterPUT.IsDefault;
                ////audit.IsDraft = masterPUT.IsDraft;
                //audit.ISONumeric = masterPUT.ISONumeric;
                //audit.ISO2Code = masterPUT.ISO2Code;
                //audit.ISO3Code = masterPUT.ISO3Code;
                //audit.FlagURL = masterPUT.FlagURL;
                //audit.ActionBy = masterPUT.ActionBy;
                //audit.ActionAt = DateTime.UtcNow;

                //CountryActivity activity = new();
                //activity.CountryId = masterPUT.Id;
                //activity.ActivityTypeId = masterPUT.ActivityTypeId;
                //activity.PageViewStartedAt = masterPUT.PageViewStartedAt;
                //activity.PageViewEndedAt = masterPUT.PageViewEndedAt;
                //activity.Browser = masterPUT.Browser;
                //activity.Location = masterPUT.Location;
                //activity.LocationURL = masterPUT.LocationURL;
                //activity.DeviceIP = masterPUT.DeviceIP;
                //activity.DeviceName = masterPUT.DeviceName; 
                //activity.OS = masterPUT.OS;
                //activity.Latitude = masterPUT.Latitude;
                //activity.Longitude = masterPUT.Longitude;

                //await repository.Add(activity);

                //transaction.Commit();

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

    public async Task<RequestResponse> Lookup()
    {
        try
        {
            var data = (from cl in repository.Set<CountryLookup>()
                        select new
                        {
                            cl.Id,
                            cl.Code,
                            cl.ISONumeric,
                            cl.ISO2Code,
                            cl.ISO3Code
                        }).AsNoTracking().AsQueryable();

            var result = await data.ToListAsync();

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
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

    public async Task<RequestResponse> GetAllLookupsLocalization()
    {
        try
        {
            var data = (from cl in repository.Set<CountryLookupLocalization>()
                        join c in repository.Set<Country>() on cl.CountryId equals c.Id
                        join l in repository.Set<Language>() on cl.LanguageId equals l.Id
                        select new
                        {
                            c.Id,
                            Country = c.Name,
                            Language = l.Name,
                            Localization = cl.Name,
                            c.ISONumeric,
                            c.ISO2Code,
                            c.ISO3Code
                        }).AsNoTracking().AsQueryable();

            var result = await data.ToListAsync();

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
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

    public async Task<RequestResponse> GetAllCurrencies()
    {
        try
        {
            var data = (from cc in repository.Set<CountryCurrency>()
                        join c in repository.Set<Country>() on cc.CountryId equals c.Id
                        join cu in repository.Set<Currency>() on cc.CurrencyId equals cu.Id
                        select new
                        {
                            cc.Id,
                            Country = c.Name,
                            Currency = cu.Name
                        }).AsNoTracking().AsQueryable();

            var result = await data.ToListAsync();

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
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

    public async Task<RequestResponse> CreateCurrency(CountryCurrencyPOST currencyPOST)
    {
        try
        {
            //var isExists = await repository.IsExists<CountryLocalization>(masterPOST.Name);

            //if (isExists == false)
            //{
                CountryCurrency masterData = new(); 
                masterData.CountryId = currencyPOST.CountryId;
                masterData.CurrencyId = currencyPOST.CurrencyId;

                await repository.Add(masterData);

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = currencyPOST
                };
            //}

            //else
            //{
            //    requestResponse = new()
            //    {
            //        StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
            //        IsSuccess = false,
            //        Message = $"{ResponseMessage.RecordExists} {masterPOST.Name}"
            //    };
            //}

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

    public async Task<RequestResponse> DeleteCurrency(int id)
    {
        try
        {
            if (id is not 0)
            {
                await repository.Delete<CountryCurrency>(id);

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

    public async Task<RequestResponse> UpdateCurrency(CountryCurrencyPUT currencyPUT)
    {
        try
        {
            //var isExists = await repository.IsExistsById<CountryLocalization>(masterPUT.Id, masterPUT.Name);
            var masterRecord = await repository.FindById<CountryCurrency>(currencyPUT.Id);

            if (masterRecord is not null)
            {
                currencyPUT.CountryId = (currencyPUT.CountryId != 0) ? currencyPUT.CountryId : masterRecord.CountryId;
                currencyPUT.CurrencyId = (currencyPUT.CurrencyId != 0) ? currencyPUT.CurrencyId : masterRecord.CurrencyId;
            }

            //if (isExists == false)
            //{ 
                masterRecord.CountryId = currencyPUT.CountryId;
                masterRecord.CurrencyId = currencyPUT.CurrencyId;

                await repository.Update(masterRecord);

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = currencyPUT
                };
            //}

            //else
            //{
            //    requestResponse = new()
            //    {
            //        StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
            //        IsSuccess = false,
            //        Message = $"{ResponseMessage.RecordExists} {masterPUT.Name}"
            //    };
            //}

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

    public async Task<RequestResponse> CreateCountryCapture(CountryCapturedPOST captured)
    {
        try
        {
            //var isExists = await repository.IsExists<CountryLocalization>(masterPOST.Name);

            //if (isExists == false)
            //{
            CountryCapture masterData = new();
            masterData.CountryId = captured.CountryId;
            masterData.ActivityTypeId = captured.ActivityTypeId;
            masterData.StorageURL = captured.StorageURL;
            masterData.FileHash = captured.FileHash;

            await repository.Add(masterData);

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                IsSuccess = true,
                Message = ResponseMessage.CreateSuccess,
                Data = captured
            };
            //}

            //else
            //{
            //    requestResponse = new()
            //    {
            //        StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
            //        IsSuccess = false,
            //        Message = $"{ResponseMessage.RecordExists} {masterPOST.Name}"
            //    };
            //}

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

    public async Task<RequestResponse> CreateAudit(CountryAudit auditPOST)
    {
        try
        {
            CountryAudit audit = new();
            audit.CountryId = auditPOST.CountryId;
            audit.CurrencyId = auditPOST.CurrencyId;
            audit.LanguageId = auditPOST.LanguageId;
            audit.DefaultCurrencyId = auditPOST.DefaultCurrencyId;
            audit.DefaultLanguageId = auditPOST.DefaultLanguageId;
            audit.StatusTypeId = auditPOST.StatusTypeId;
            audit.ActionTypeId = auditPOST.ActionTypeId;
            audit.Code = auditPOST.Code;
            audit.Name = auditPOST.Name;
            audit.IsDefault = auditPOST.IsDefault;
            audit.ISONumeric = auditPOST.ISONumeric;
            audit.ISO2Code = auditPOST.ISO2Code;
            audit.ISO3Code = auditPOST.ISO3Code;
            audit.FlagURL = auditPOST.FlagURL;
            audit.ActionBy = auditPOST.ActionBy;
            audit.ActionAt = DateTime.UtcNow;

            await repository.Add(audit);

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                IsSuccess = true,
                Message = ResponseMessage.CreateSuccess,
                Data = auditPOST
            };

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

    public async Task<RequestResponse> CreateActivity(CountryActivity activityPOST)
    {
        try
        {
            CountryActivity activity = new();
            activity.CountryId = activityPOST.CountryId;
            activity.ActivityTypeId = activityPOST.ActivityTypeId;
            activity.PageViewStartedAt = activityPOST.PageViewStartedAt;
            activity.PageViewEndedAt = activityPOST.PageViewEndedAt;
            activity.Browser = activityPOST.Browser;
            activity.Location = activityPOST.Location;
            activity.LocationURL = activityPOST.LocationURL;
            activity.DeviceIP = activityPOST.DeviceIP;
            activity.DeviceName = activityPOST.DeviceName;
            activity.OS = activityPOST.OS;
            activity.Latitude = activityPOST.Latitude;
            activity.Longitude = activityPOST.Longitude;

            await repository.Add(activity);

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                IsSuccess = true,
                Message = ResponseMessage.CreateSuccess,
                Data = activityPOST
            };

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

    public async Task<RequestResponse> Import(List<CountryImport> imports)
    {
        RequestResponse response = new();
        try
        {
            foreach (var import in imports)
            {
                
                if (import.Id == 0)
                {
                    CountryPOST masterData = new();
                    masterData.TenantId = import.TenantId;
                    masterData.DefaultLanguageId = import.DefaultLanguageId;
                    masterData.DefaultCurrencyId = import.DefaultCurrencyId;
                    masterData.StatusTypeId = import.StatusTypeId;
                    masterData.Name = import.Name;
                    masterData.Code = import.Code;
                    masterData.IsDefault = import.IsDefault;
                    masterData.ISONumeric = import.ISONumeric;
                    masterData.ISO2Code = import.ISO2Code;
                    masterData.ISO3Code = import.ISO3Code;
                    masterData.FlagURL = import.FlagURL;

                    //var result = await Create(masterData);

                    var task = Create(masterData);
                    var result = await Task.WhenAll(task);
                    response.Message = result.FirstOrDefault().Message;
                    response.IsSuccess = result.FirstOrDefault().IsSuccess;
                    response.StatusCode = result.FirstOrDefault().StatusCode;
                    response.Data = result.FirstOrDefault().Data;
                }

                else
                {
                    CountryPUT masterData = new();
                    masterData.TenantId = import.TenantId;
                    masterData.DefaultLanguageId = import.DefaultLanguageId;
                    masterData.DefaultCurrencyId = import.DefaultCurrencyId;
                    masterData.StatusTypeId = import.StatusTypeId;
                    masterData.Name = import.Name;
                    masterData.Code = import.Code;
                    masterData.IsDefault = import.IsDefault;
                    masterData.ISONumeric = import.ISONumeric;
                    masterData.ISO2Code = import.ISO2Code;
                    masterData.ISO3Code = import.ISO3Code;
                    masterData.FlagURL = import.FlagURL;

                    var task = Update(masterData);
                    var result = await Task.WhenAll(task);

                    response.Message = result.FirstOrDefault().Message;
                    response.IsSuccess = result.FirstOrDefault().IsSuccess;
                    response.StatusCode = result.FirstOrDefault().StatusCode;
                    response.Data = result.FirstOrDefault().Data;
                }
            }

            return response;
        }

        catch
        {
            response = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return response;
        }
    }

    public async Task<RequestResponse> DeleteCountryCapture(int id)
    {
        try
        {
            if (id is not 0)
            {
                await repository.Delete<CountryCapture>(id);

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

    public async Task<RequestResponse> ImportCurrency(List<CountryCurrencyPOST> imports)
    {
        try
        {
            requestResponse = new();

            foreach (var import in imports)
            {
                var task = CreateCurrency(import);
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
}
