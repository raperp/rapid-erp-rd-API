using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.KitchenDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Entities.TableModules;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services
{
    public class KitchenService(RapidERPDbContext context, IShared shared) : IKitchen
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
                    //masterData.CreatedBy = masterPOST.CreatedBy;
                    masterData.CreatedAt = DateTime.Now;

                    await context.Kitchens.AddAsync(masterData);
                    await context.SaveChangesAsync();

                    KitchenAudit audit = new();
                    audit.Name = masterPOST.Name;
                    audit.Description = masterPOST.Description;
                    audit.PrinterId = masterPOST.PrinterId;
                    audit.KitchenId = masterData.Id;
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

                    await context.KitchenAudits.AddAsync(audit);
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
                var isAuditExists = await context.KitchenAudits.AsNoTracking().AnyAsync(x => x.KitchenId == id);

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
                    await context.KitchenAudits.Where(x => x.KitchenId == id).ExecuteDeleteAsync();
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

        public async Task<RequestResponse> GetAll(int skip, int take)
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
                                Status = st.Name,
                                k.CreatedBy,
                                k.CreatedAt
                            }).AsNoTracking().AsQueryable();

                if (skip == 0 || take == 0)
                {
                    result.Count = await shared.GetCounts<Kitchen>();
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
                    result.Count = await shared.GetCounts<Kitchen>();
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

        public async Task<RequestResponse> GetAllAudits(int skip, int take)
        {
            try
            {
                var data = (from ka in context.KitchenAudits
                            join k in context.Kitchens on ka.KitchenId equals k.Id
                            join at in context.ActionTypes on ka.ActionTypeId equals at.Id
                            //join st in context.StatusTypes on ka.StatusTypeId equals st.Id
                            select new
                            {
                                ka.Id,
                                Kitchen = k.Name,
                                ka.Name,
                                ka.Description,
                                ka.PrinterId,
                                //ExportType = et.Name,
                                ActionType = at.Name,
                                //StatusType = st.Name,
                                ka.ExportTo,
                                ka.SourceURL,
                                //ka.IsDefault,
                                ka.Browser,
                                ka.DeviceName,
                                ka.Location,
                                ka.DeviceIP,
                                //ka.GoogleMapUrl,
                                ka.Latitude,
                                ka.Longitude,
                                ka.ActionBy,
                                ka.ActionAt
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

        public Task<RequestResponse> SoftDeleteRestore(SoftDeleteRestore softDeleteRestore)
        {
            throw new NotImplementedException();
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
                    .SetProperty(x => x.PrinterId, masterPUT.PrinterId)
                    //.SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                    //.SetProperty(x => x.UpdatedBy, masterPUT.UpdatedBy)
                    .SetProperty(x => x.UpdatedAt, DateTime.Now));

                    KitchenAudit audit = new();
                    audit.Name = masterPUT.Name;
                    audit.Description = masterPUT.Description;
                    audit.PrinterId = masterPUT.PrinterId;
                    audit.KitchenId = masterPUT.Id;
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

                    await context.KitchenAudits.AddAsync(audit);
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
