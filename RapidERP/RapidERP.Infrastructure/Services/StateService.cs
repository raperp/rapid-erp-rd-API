using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.StateDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services
{
    public class StateService(RapidERPDbContext context, IShared shared) : IState
    {
        RequestResponse requestResponse { get; set; }

        public async Task<RequestResponse> CreateBulk(List<StatePOST> masterPOSTs)
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

        public async Task<RequestResponse> CreateSingle(StatePOST masterPOST)
        {
            try
            {
                await using var transaction = await context.Database.BeginTransactionAsync();
                var isExists = await context.States.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

                if (isExists == false)
                {
                    State masterData = new();
                    masterData.Name = masterPOST.Name;
                    masterData.CountryId = masterPOST.CountryId;
                    masterData.MenuId = masterPOST.MenuId;
                    masterData.StatusTypeId = masterPOST.StatusTypeId;
                    masterData.LanguageId = masterPOST.LanguageId;
                    masterData.Code = masterPOST.Code;
                    masterData.IsDefault = masterPOST.IsDefault;
                    //masterData.CreatedBy = masterPOST.CreatedBy;
                    masterData.CreatedAt = DateTime.Now;

                    await context.States.AddAsync(masterData);
                    await context.SaveChangesAsync();

                    StateAudit audit = new();
                    audit.Name = masterPOST.Name;
                    audit.CountryId = masterPOST.CountryId;
                    audit.MenuId = masterPOST.MenuId;
                    audit.StateId = masterData.Id;
                    audit.LanguageId = masterPOST.LanguageId;
                    audit.Code = masterPOST.Code;
                    //audit.IsDefault = masterPOST.IsDefault;
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

                    await context.StateAudits.AddAsync(audit);
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
                var isAuditExists = await context.StateAudits.AsNoTracking().AnyAsync(x => x.StateId == id);

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
                    await context.StateAudits.Where(x => x.StateId == id).ExecuteDeleteAsync();
                }

                var isExists = await context.States.AsNoTracking().AnyAsync(x => x.Id == id);

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
                    await context.States.Where(x => x.Id == id).ExecuteDeleteAsync();
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

                var data = (from s in context.States
                            join c in context.Countries on s.CountryId equals c.Id
                            join l in context.Languages on s.LanguageId equals l.Id
                            join st in context.StatusTypes on s.StatusTypeId equals st.Id
                            select new
                            {
                                s.Id,
                                s.Name,
                                s.Code,
                                s.IsDefault,
                                Country = c.Name,
                                Language = l.Name,
                                Status = st.Name,
                                c.CreatedBy,
                                c.CreatedAt
                            }).AsNoTracking().AsQueryable();

                if (skip == 0 || take == 0)
                {
                    result.Count = await shared.GetCounts<State>();
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
                    result.Count = await shared.GetCounts<State>();
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
                var data = (from sa in context.StateAudits
                            join c in context.Countries on sa.CountryId equals c.Id
                            //join et in context.ExportTypes on sa.ExportTypeId equals et.Id
                            join at in context.ActionTypes on sa.ActionTypeId equals at.Id
                            //join st in context.StatusTypes on sa.StatusTypeId equals st.Id
                            select new
                            {
                                sa.Id,
                                Country = c.Name,
                                sa.Name,
                                //ExportType = et.Name,
                                Action = at.Name,
                                //Status = st.Name,
                                sa.ExportTo,
                                sa.SourceURL,
                                //sa.IsDefault,
                                sa.Code,
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
            var result = await shared.GetSingle<State>(id);
            return result;
        }

        public Task<RequestResponse> SoftDelete(DeleteDTO softDelete)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> SoftDeleteRestore(DeleteDTO softDeleteRestore)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResponse> Update(StatePUT masterPUT)
        {
            try
            {
                await using var transaction = await context.Database.BeginTransactionAsync();
                var isExists = await context.States.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

                if (isExists == false)
                {
                    await context.States.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name, masterPUT.Name)
                    .SetProperty(x => x.CountryId, masterPUT.CountryId)
                    .SetProperty(x => x.MenuId, masterPUT.MenuId)
                    //.SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                    .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                    .SetProperty(x => x.Code, masterPUT.Code)
                    .SetProperty(x => x.IsDefault, masterPUT.IsDefault)
                    //.SetProperty(x => x.UpdatedBy, masterPUT.UpdatedBy)
                    .SetProperty(x => x.UpdatedAt, DateTime.Now));

                    StateAudit audit = new();
                    audit.Name = masterPUT.Name;
                    audit.CountryId = masterPUT.CountryId;
                    audit.MenuId = masterPUT.MenuId;
                    audit.StateId = masterPUT.Id;
                    audit.LanguageId = masterPUT.LanguageId;
                    audit.Code = masterPUT.Code;
                    //audit.IsDefault = masterPUT.IsDefault;
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

                    await context.StateAudits.AddAsync(audit);
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
