using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.TableDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.TableModules;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;
using ITable = RapidERP.Application.Interfaces.ITable;

namespace RapidERP.Infrastructure.Services;

public class TableService(RapidERPDbContext context, IShared shared) : ITable
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<TablePOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(TablePOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Tables.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Table masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.Description = masterPOST.Description;
                masterData.TotalPersons = masterPOST.TotalPersons;
                masterData.StatusTypeId = masterPOST.StatusTypeId;

                await context.Tables.AddAsync(masterData);
                await context.SaveChangesAsync();

                TableHistory history = new();
                history.Name = masterPOST.Name;
                history.Description = masterPOST.Description;
                history.TotalPersons = masterPOST.TotalPersons;
                history.TableId = masterData.Id;
                //history.StatusTypeId = masterPOST.StatusTypeId;
                history.ActionTypeId = masterPOST.ActionTypeId;
                history.ExportTypeId = masterPOST.ExportTypeId;
                history.ExportTo = masterPOST.ExportTo;
                history.SourceURL = masterPOST.SourceURL;
                //history.IsDefault = masterPOST.IsDefault;
                history.Browser = masterPOST.Browser;
                history.DeviceName = masterPOST.DeviceName;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                //history.GoogleMapUrl = masterPOST.GoogleMapUrl;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                //history.ActionBy = masterPOST.CreatedBy;
                history.ActionAt = DateTime.Now;

                await context.TableHistory.AddAsync(history);
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
            var ishistoryExists = await context.TableHistory.AsNoTracking().AnyAsync(x => x.TableId == id);

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
                await context.TableHistory.Where(x => x.TableId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Tables.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.Tables.Where(x => x.Id == id).ExecuteDeleteAsync();
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

            var data = (from t in context.Tables
                        join st in context.StatusTypes on t.StatusTypeId equals st.Id
                        select new
                        {
                            t.Id,
                            t.Name,
                            t.Description,
                            t.TotalPersons,
                            Status = st.Name
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Table>();
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
                result.Count = await shared.GetCounts<Table>();
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
            var data = (from ta in context.TableHistory
                        join t in context.Tables on ta.TableId equals t.Id
                        join at in context.ActionTypes on ta.ActionTypeId equals at.Id
                        //join st in context.StatusTypes on ta.StatusTypeId equals st.Id
                        select new
                        {
                            ta.Id,
                            ta.Name,
                            ta.Description,
                            ta.TotalPersons,
                            Table = t.Name,
                            //ExportType = et.Name,
                            ActionType = at.Name,
                            //StatusType = st.Name,
                            ta.ExportTo,
                            ta.SourceURL,
                            //ta.IsDefault,
                            ta.Browser,
                            ta.DeviceName,
                            ta.Location,
                            ta.DeviceIP,
                            //ta.GoogleMapUrl,
                            ta.Latitude,
                            ta.Longitude,
                            ta.ActionBy,
                            ta.ActionAt
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
        var result = await shared.GetSingle<Table>(id);
        return result;
    }

    public Task<dynamic> SoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> Update(TablePUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Tables.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Tables.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Description, masterPUT.Description)
                .SetProperty(x => x.TotalPersons, masterPUT.TotalPersons));

                TableHistory history = new();
                history.Name = masterPUT.Name;
                history.Description = masterPUT.Description;
                history.TotalPersons = masterPUT.TotalPersons;
                history.TableId = masterPUT.Id;
                //history.StatusTypeId = masterPUT.StatusTypeId;
                history.ActionTypeId = masterPUT.ActionTypeId;
                history.ExportTypeId = masterPUT.ExportTypeId;
                history.ExportTo = masterPUT.ExportTo;
                history.SourceURL = masterPUT.SourceURL;
                //history.IsDefault = masterPUT.IsDefault;
                history.Browser = masterPUT.Browser;
                history.DeviceName = masterPUT.DeviceName;
                history.Location = masterPUT.Location;
                history.DeviceIP = masterPUT.DeviceIP;
                //history.GoogleMapUrl = masterPUT.GoogleMapUrl;
                history.Latitude = masterPUT.Latitude;
                history.Longitude = masterPUT.Longitude;
                //history.ActionBy = masterPUT.UpdatedBy;
                history.ActionAt = DateTime.Now;

                await context.TableHistory.AddAsync(history);
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
