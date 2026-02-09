using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.SupplierDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.SupplierModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class SupplierService(RapidERPDbContext context, ISharedService shared) : ISupplierService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<SupplierPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(SupplierPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Suppliers.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Supplier masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.CountryId = masterPOST.CountryId;
                masterData.PaymentTermsId = masterPOST.PaymentTermsId;
                masterData.PaymentTypeId = masterPOST.PaymentTypeId;
                masterData.DueDays = masterPOST.DueDays;
                masterData.DepositTypeId = masterPOST.DepositTypeId;
                masterData.PaymentTypeId = masterPOST.PaymentTypeId;
                masterData.DepositAmount = masterPOST.DepositAmount;
                masterData.CurrencyId = masterPOST.CurrencyId;
                masterData.ExchangeRate = masterPOST.ExchangeRate;
                masterData.LocalAmount = masterPOST.LocalAmount;
                masterData.ContactPersonName = masterPOST.ContactPersonName;
                masterData.Mobile = masterPOST.Mobile;
                masterData.Email = masterPOST.Email;
                masterData.Website = masterPOST.Website;
                //masterData.MenuModuleId = masterPOST.MenuModuleId;
                masterData.TenantId = masterPOST.TenantId;
                //masterData.StatusTypeId = masterPOST.StatusTypeId;
                //masterData.LanguageId = masterPOST.LanguageId;

                await context.Suppliers.AddAsync(masterData);
                await context.SaveChangesAsync();

                SupplierHistory history = new();
                history.SupplierId = masterData.Id;
                history.Name = masterPOST.Name;
                history.CountryId = masterPOST.CountryId;
                history.PaymentTermsId = masterPOST.PaymentTermsId;
                history.PaymentTypeId = masterPOST.PaymentTypeId;
                history.DueDays = masterPOST.DueDays;
                history.DepositTypeId = masterPOST.DepositTypeId;
                history.PaymentTypeId = masterPOST.PaymentTypeId;
                history.DepositAmount = masterPOST.DepositAmount;
                history.CurrencyId = masterPOST.CurrencyId;
                history.ExchangeRate = masterPOST.ExchangeRate;
                history.LocalAmount = masterPOST.LocalAmount;
                history.ContactPersonName = masterPOST.ContactPersonName;
                history.Mobile = masterPOST.Mobile;
                history.Email = masterPOST.Email;
                history.Website = masterPOST.Website;
                //history.TenantId = masterPOST.TenantId;
                //history.MenuModuleId = masterPOST.MenuModuleId;
                //history.ActionTypeId = masterPOST.ActionTypeId;
                //history.LanguageId = masterPOST.LanguageId;
                //history.ExportTypeId = masterPOST.ExportTypeId;
                //history.ExportTo = masterPOST.ExportTo;
                //history.SourceURL = masterPOST.SourceURL;
                history.IsDefault = masterPOST.IsDefault;
                history.IsDraft = masterPOST.IsDraft;
                //history.Browser = masterPOST.Browser;
                //history.Location = masterPOST.Location;
                //history.DeviceIP = masterPOST.DeviceIP;
                //history.LocationURL = masterPOST.LocationURL;
                //history.DeviceName = masterPOST.DeviceName;
                //history.Latitude = masterPOST.Latitude;
                //history.Longitude = masterPOST.Longitude;
                //history.ActionBy = masterPOST.ActionBy;
                //history.ActionAt = DateTime.Now;

                await context.SupplierHistory.AddAsync(history);
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
            var ishistoryExists = await context.SupplierHistory.AsNoTracking().AnyAsync(x => x.SupplierId == id);

            if (ishistoryExists == false)
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
                await context.SupplierHistory.Where(x => x.SupplierId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Tenants.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.Suppliers.Where(x => x.Id == id).ExecuteDeleteAsync();
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

    public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from s in context.Suppliers
                        //join st in context.StatusTypes on s.StatusTypeId equals st.Id
                        join cu in context.Currencies on s.CurrencyId equals cu.Id
                        join co in context.Countries on s.CountryId equals co.Id
                        join t in context.Tenants on s.TenantId equals t.Id
                        //join l in context.Languages on s.LanguageId equals l.Id
                        //join mm in context.MenuModules on s.MenuModuleId equals mm.Id
                        select new
                        {
                            s.Id,
                            s.Name,
                            s.PaymentTermsId,
                            s.PaymentTypeId,
                            s.DueDays,
                            s.DepositTypeId,
                            s.DepositAmount,
                            s.ExchangeRate,
                            s.Website,
                            s.LocalAmount,
                            s.ContactPersonName,
                            s.Mobile,
                            s.Email,
                            //MenuModule = mm.Name,
                            Tanent = t.Name,
                            //Language = l.Name,
                            //Status = st.Name,
                            Country = co.Name,
                            Currency = cu.Name
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Tenant>(pageSize);
                result.Data = await data.ToListAsync();

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
                result.Count = await shared.GetCounts<Tenant>(pageSize);
                result.Data = await data.Skip(skip).Take(take).ToListAsync();

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

    public Task<RequestResponse> GetAll(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    {
        try
        {
            var data = (from sh in context.SupplierHistory
                        join s in context.Suppliers on sh.SupplierId equals s.Id
                        join co in context.Countries on sh.CountryId equals co.Id
                        join cu in context.Currencies on sh.CurrencyId equals cu.Id
                        //join et in context.ExportTypes on sh.ExportTypeId equals et.Id
                        join at in context.ActionTypes on sh.ActionTypeId equals at.Id
                        //join t in context.Tenants on sh.TenantId equals t.Id
                        //join l in context.Languages on sh.LanguageId equals l.Id
                        //join mm in context.MenuModules on sh.MenuModuleId equals mm.Id
                        select new
                        {
                            sh.Id,
                            sh.Name,
                            sh.PaymentTermsId,
                            sh.DueDays,
                            sh.DepositAmount,
                            sh.ExchangeRate,
                            sh.LocalAmount,
                            sh.ContactPersonName,
                            sh.Mobile,
                            sh.Email,
                            sh.Website,
                            Supplier = s.Name,
                            Country = co.Name,
                            Currency = cu.Name,
                            //Tanent = t.Name,
                            //MenuModule = mm.Name,
                            Action = at.Name,
                            //Language = l.Name,
                            //ExportType = et.Name,
                            //sh.ExportTo,
                            //sh.SourceURL,
                            sh.IsDefault,
                            sh.IsDraft,
                            //sh.Browser,
                            //sh.Location,
                            //sh.DeviceIP,
                            //sh.LocationURL,
                            //sh.DeviceName,
                            //sh.Latitude,
                            //sh.Longitude,
                            //sh.ActionBy,
                            //sh.ActionAt
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
        var result = await shared.GetSingle<Supplier>(id);
        return result;
    }

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = await shared.SoftDelete<Supplier>(id);
        return result;
    }

    public async Task<RequestResponse> Update(SupplierPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Suppliers.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Suppliers.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.CountryId, masterPUT.CountryId)
                .SetProperty(x => x.PaymentTermsId, masterPUT.PaymentTermsId)
                .SetProperty(x => x.PaymentTypeId, masterPUT.PaymentTypeId)
                .SetProperty(x => x.DueDays, masterPUT.DueDays)
                .SetProperty(x => x.DepositTypeId, masterPUT.DepositTypeId)
                .SetProperty(x => x.DepositAmount, masterPUT.DepositAmount)
                .SetProperty(x => x.CurrencyId, masterPUT.CurrencyId)
                .SetProperty(x => x.ExchangeRate, masterPUT.ExchangeRate)
                .SetProperty(x => x.LocalAmount, masterPUT.LocalAmount)
                .SetProperty(x => x.ContactPersonName, masterPUT.ContactPersonName)
                .SetProperty(x => x.Mobile, masterPUT.Mobile)
                .SetProperty(x => x.Email, masterPUT.Email)
                .SetProperty(x => x.Website, masterPUT.Website)
                //.SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                .SetProperty(x => x.TenantId, masterPUT.TenantId));

                SupplierHistory history = new();
                history.SupplierId = masterPUT.Id;
                history.Name = masterPUT.Name;
                history.CountryId = masterPUT.CountryId;
                history.PaymentTermsId = masterPUT.PaymentTermsId;
                history.PaymentTypeId = masterPUT.PaymentTypeId;
                history.DueDays = masterPUT.DueDays;
                history.DepositTypeId = masterPUT.DepositTypeId;
                history.PaymentTypeId = masterPUT.PaymentTypeId;
                history.DepositAmount = masterPUT.DepositAmount;
                history.CurrencyId = masterPUT.CurrencyId;
                history.ExchangeRate = masterPUT.ExchangeRate;
                history.LocalAmount = masterPUT.LocalAmount;
                history.ContactPersonName = masterPUT.ContactPersonName;
                history.Mobile = masterPUT.Mobile;
                history.Email = masterPUT.Email;
                history.Website = masterPUT.Website;
                //history.TenantId = masterPUT.TenantId;
                //history.MenuModuleId = masterPUT.MenuModuleId;
                //history.ActionTypeId = masterPUT.ActionTypeId;
                //history.LanguageId = masterPUT.LanguageId;
                //history.ExportTypeId = masterPUT.ExportTypeId;
                //history.ExportTo = masterPUT.ExportTo;
                //history.SourceURL = masterPUT.SourceURL;
                history.IsDefault = masterPUT.IsDefault;
                history.IsDraft = masterPUT.IsDraft;
                //history.Browser = masterPUT.Browser;
                //history.Location = masterPUT.Location;
                //history.DeviceIP = masterPUT.DeviceIP;
                //history.LocationURL = masterPUT.LocationURL;
                //history.DeviceName = masterPUT.DeviceName;
                //history.Latitude = masterPUT.Latitude;
                //history.Longitude = masterPUT.Longitude;
                //history.ActionBy = masterPUT.ActionBy;
                //history.ActionAt = DateTime.Now;

                await context.SupplierHistory.AddAsync(history);
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

    public Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus)
    {
        throw new NotImplementedException();
    }

    Task<RequestResponse> IBase<SupplierPOST, SupplierPUT>.GetSingle(int id)
    {
        throw new NotImplementedException();
    }

    
}
