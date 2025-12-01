using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.SupplierDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.SupplierModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class SupplierService(RapidERPDbContext context, IShared shared) : ISupplier
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

            //requestResponse = new()
            //{
            //    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
            //    IsSuccess = true,
            //    Message = ResponseMessage.CreateSuccess,
            //    Data = masterPOSTs
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
                masterData.StatusTypeId = masterPOST.StatusTypeId;

                await context.Suppliers.AddAsync(masterData);
                await context.SaveChangesAsync();

                SupplierHistory audit = new();
                audit.Name = masterPOST.Name;
                audit.CountryId = masterPOST.CountryId;
                audit.PaymentTermsId = masterPOST.PaymentTermsId;
                audit.PaymentTypeId = masterPOST.PaymentTypeId;
                audit.DueDays = masterPOST.DueDays;
                audit.DepositTypeId = masterPOST.DepositTypeId;
                audit.PaymentTypeId = masterPOST.PaymentTypeId;
                audit.DepositAmount = masterPOST.DepositAmount;
                audit.CurrencyId = masterPOST.CurrencyId;
                audit.ExchangeRate = masterPOST.ExchangeRate;
                audit.LocalAmount = masterPOST.LocalAmount;
                audit.ContactPersonName = masterPOST.ContactPersonName;
                audit.Mobile = masterPOST.Mobile;
                audit.Email = masterPOST.Email;
                audit.Website = masterPOST.Website;
                //audit.StatusTypeId = masterPOST.StatusTypeId;
                audit.ActionTypeId = masterPOST.ActionTypeId;
                audit.ExportTypeId = masterPOST.ExportTypeId;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                //audit.IsDefault = masterPOST.IsDefault;
                audit.Browser = masterPOST.Browser;
                audit.DeviceName = masterPOST.DeviceName;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                //audit.GoogleMapUrl = masterPOST.GoogleMapUrl;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                //audit.ActionBy = masterPOST.CreatedBy;
                audit.ActionAt = DateTime.Now;

                await context.SupplierHistory.AddAsync(audit);
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
            var isAuditExists = await context.SupplierHistory.AsNoTracking().AnyAsync(x => x.SupplierId == id);

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

    public async Task<RequestResponse> GetAll(int skip, int take)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from s in context.Suppliers
                        join st in context.StatusTypes on s.StatusTypeId equals st.Id
                        join cu in context.Currencies on s.StatusTypeId equals cu.Id
                        join co in context.Countries on s.StatusTypeId equals co.Id
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
                            Status = st.Name,
                            Country = co.Name,
                            Currency = cu.Name
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Tenant>();
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
                result.Count = await shared.GetCounts<Tenant>();
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

    public async Task<RequestResponse> GetHistory(int skip, int take)
    {
        try
        {
            var data = (from sa in context.SupplierHistory
                        join s in context.Suppliers on sa.SupplierId equals s.Id
                        join co in context.Countries on sa.CountryId equals co.Id
                        join cu in context.Currencies on sa.CurrencyId equals cu.Id
                        join at in context.ActionTypes on sa.ActionTypeId equals at.Id
                        //join st in context.StatusTypes on sa.StatusTypeId equals st.Id
                        select new
                        {
                            sa.Id,
                            sa.Name,
                            sa.PaymentTermsId,
                            sa.DueDays,
                            sa.DepositAmount,
                            sa.ExchangeRate,
                            sa.LocalAmount,
                            sa.ContactPersonName,
                            sa.Mobile,
                            sa.Email,
                            sa.Website,
                            Supplier = s.Name,
                            Country = co.Name,
                            Currency = cu.Name,
                            //ExportType = et.Name,
                            ActionType = at.Name,
                            //StatusType = st.Name,
                            sa.ExportTo,
                            sa.SourceURL,
                            //sa.IsDefault,
                            sa.Browser,
                            sa.DeviceName,
                            sa.Location,
                            sa.DeviceIP,
                            //sa.GoogleMapUrl,
                            sa.Latitude,
                            sa.Longitude,
                            sa.ActionBy,
                            sa.ActionAt
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

    public Task<dynamic> SoftDelete(int id)
    {
        throw new NotImplementedException();
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
                .SetProperty(x => x.DueDays, masterPUT.DueDays)
                .SetProperty(x => x.DepositTypeId, masterPUT.DepositTypeId)
                .SetProperty(x => x.PaymentTypeId, masterPUT.PaymentTypeId)
                .SetProperty(x => x.DepositAmount, masterPUT.DepositAmount)
                .SetProperty(x => x.CurrencyId, masterPUT.CurrencyId)
                .SetProperty(x => x.ExchangeRate, masterPUT.ExchangeRate)
                .SetProperty(x => x.LocalAmount, masterPUT.LocalAmount)
                .SetProperty(x => x.ContactPersonName, masterPUT.ContactPersonName)
                .SetProperty(x => x.Mobile, masterPUT.Mobile)
                .SetProperty(x => x.Email, masterPUT.Email)
                .SetProperty(x => x.Website, masterPUT.Website));

                SupplierHistory audit = new();
                audit.Name = masterPUT.Name;
                audit.CountryId = masterPUT.CountryId;
                audit.PaymentTermsId = masterPUT.PaymentTermsId;
                audit.PaymentTypeId = masterPUT.PaymentTypeId;
                audit.DueDays = masterPUT.DueDays;
                audit.DepositTypeId = masterPUT.DepositTypeId;
                audit.PaymentTypeId = masterPUT.PaymentTypeId;
                audit.DepositAmount = masterPUT.DepositAmount;
                audit.CurrencyId = masterPUT.CurrencyId;
                audit.ExchangeRate = masterPUT.ExchangeRate;
                audit.LocalAmount = masterPUT.LocalAmount;
                audit.ContactPersonName = masterPUT.ContactPersonName;
                audit.Mobile = masterPUT.Mobile;
                audit.Email = masterPUT.Email;
                audit.Website = masterPUT.Website;
                //audit.StatusTypeId = masterPUT.StatusTypeId;
                audit.ActionTypeId = masterPUT.ActionTypeId;
                audit.ExportTypeId = masterPUT.ExportTypeId;
                audit.ExportTo = masterPUT.ExportTo;
                audit.SourceURL = masterPUT.SourceURL;
                //audit.IsDefault = masterPUT.IsDefault;
                audit.Browser = masterPUT.Browser;
                audit.DeviceName = masterPUT.DeviceName;
                audit.Location = masterPUT.Location;
                audit.DeviceIP = masterPUT.DeviceIP;
                //audit.GoogleMapUrl = masterPUT.GoogleMapUrl;
                audit.Latitude = masterPUT.Latitude;
                audit.Longitude = masterPUT.Longitude;
                //audit.ActionBy = masterPUT.UpdatedBy;
                audit.ActionAt = DateTime.Now;

                await context.SupplierHistory.AddAsync(audit);
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
