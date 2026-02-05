using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.KitchenDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services
{
    public class KitchenService(RapidERPDbContext context, ISharedService shared) : IKitchenService
    {
        RequestResponse requestResponse { get; set; }

        public async Task<RequestResponse> CreateBulk(List<KitchenPOST> masterPOSTs)
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

        public async Task<RequestResponse> CreateSingle(KitchenPOST masterPOST)
        {
            try
            {
                await using var transaction = await context.Database.BeginTransactionAsync();
                var isExists = await context.Kitchens.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

                if (isExists == false)
                {
                    Kitchen masterData = new();
                    masterData.Name = masterPOST.Name;
                    masterData.Description = masterPOST.Description;
                    masterData.PrinterId = masterPOST.PrinterId;
                    masterData.StatusTypeId = masterPOST.StatusTypeId;
                    masterData.TenantId = masterPOST.TenantId;
                    masterData.MenuModuleId = masterPOST.MenuModuleId;

                    await context.Kitchens.AddAsync(masterData);
                    //await context.SaveChangesAsync();

                    KitchenHistory history = new();
                    history.Name = masterPOST.Name;
                    history.Description = masterPOST.Description;
                    history.PrinterId = masterPOST.PrinterId;
                    history.KitchenId = masterData.Id;
                    history.TenantId = masterPOST.TenantId;
                    history.MenuModuleId = masterPOST.MenuModuleId;
                    history.ActionTypeId = masterPOST.ActionTypeId;
                    history.ExportTypeId = masterPOST.ExportTypeId;
                    history.ExportTo = masterPOST.ExportTo;
                    history.SourceURL = masterPOST.SourceURL;
                    //history.Browser = masterPOST.Browser;
                    //history.Location = masterPOST.Location;
                    //history.DeviceIP = masterPOST.DeviceIP;
                    //history.LocationURL = masterPOST.LocationURL;
                    //history.DeviceName = masterPOST.DeviceName;
                    //history.Latitude = masterPOST.Latitude;
                    //history.Longitude = masterPOST.Longitude;
                    //history.ActionBy = masterPOST.ActionBy;
                    //history.ActionAt = DateTime.Now;

                    await context.KitchenHistory.AddAsync(history);
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
                var ishistoryExists = await context.KitchenHistory.AsNoTracking().AnyAsync(x => x.KitchenId == id);

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
                    await context.KitchenHistory.Where(x => x.KitchenId == id).ExecuteDeleteAsync();
                }

                var isExists = await context.Kitchens.AsNoTracking().AnyAsync(x => x.Id == id);

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
                    await context.Kitchens.Where(x => x.Id == id).ExecuteDeleteAsync();
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

                var data = (from k in context.Kitchens
                            join st in context.StatusTypes on k.StatusTypeId equals st.Id
                            select new
                            {
                                k.Id,
                                k.Name,
                                k.Description,
                                k.PrinterId,
                                Status = st.Name
                            }).AsNoTracking().AsQueryable();

                if (skip == 0 || take == 0)
                {
                    result.Count = await shared.GetCounts<Kitchen>(pageSize);
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
                    result.Count = await shared.GetCounts<Kitchen>(pageSize);
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

        public async Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
        {
            try
            {
                var data = (from ka in context.KitchenHistory
                            join k in context.Kitchens on ka.KitchenId equals k.Id
                            join at in context.ActionTypes on ka.ActionTypeId equals at.Id
                            join et in context.ExportTypes on ka.ExportTypeId equals et.Id
                            select new
                            {
                                ka.Id,
                                Kitchen = k.Name,
                                ka.Name,
                                ka.Description,
                                ka.PrinterId,
                                ExportType = et.Name,
                                ActionType = at.Name,
                                ka.ExportTo,
                                ka.SourceURL,
                                //ka.Browser,
                                //ka.Location,
                                //ka.DeviceIP,
                                //ka.LocationURL,
                                //ka.DeviceName,
                                //ka.Latitude,
                                //ka.Longitude,
                                //ka.ActionBy,
                                //ka.ActionAt
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
            var result = await shared.GetSingle<Kitchen>(id);
            return result;
        }

        public Task<RequestResponse> GetTemplate()
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> SoftDelete(int id)
        {
            var result = await shared.SoftDelete<Kitchen>(id);
            return result;
        }

        public async Task<RequestResponse> Update(KitchenPUT masterPUT)
        {
            try
            {
                await using var transaction = await context.Database.BeginTransactionAsync();
                var isExists = await context.Kitchens.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

                if (isExists == false)
                {
                    await context.Kitchens.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name, masterPUT.Name)
                    .SetProperty(x => x.Description, masterPUT.Description)
                    .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                    .SetProperty(x => x.TenantId, masterPUT.TenantId)
                    .SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                    .SetProperty(x => x.PrinterId, masterPUT.PrinterId));

                    KitchenHistory history = new();
                    history.Name = masterPUT.Name;
                    history.Description = masterPUT.Description;
                    history.PrinterId = masterPUT.PrinterId;
                    history.KitchenId = masterPUT.Id;
                    history.TenantId = masterPUT.TenantId;
                    history.MenuModuleId = masterPUT.MenuModuleId;
                    history.ActionTypeId = masterPUT.ActionTypeId;
                    history.ExportTypeId = masterPUT.ExportTypeId;
                    history.ExportTo = masterPUT.ExportTo;
                    history.SourceURL = masterPUT.SourceURL;
                    //history.Browser = masterPUT.Browser;
                    //history.Location = masterPUT.Location;
                    //history.DeviceIP = masterPUT.DeviceIP;
                    //history.LocationURL = masterPUT.LocationURL;
                    //history.DeviceName = masterPUT.DeviceName;
                    //history.Latitude = masterPUT.Latitude;
                    //history.Longitude = masterPUT.Longitude;
                    //history.ActionBy = masterPUT.ActionBy;
                    //history.ActionAt = DateTime.Now;

                    await context.KitchenHistory.AddAsync(history);
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
}
