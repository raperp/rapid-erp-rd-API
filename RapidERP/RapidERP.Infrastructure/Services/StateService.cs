using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.StateDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services
{
    public class StateService(RapidERPDbContext context, ISharedService shared) : IStateService
    {
        RequestResponse requestResponse { get; set; }

        public async Task<RequestResponse> CreateBulk(List<StatePOST> masterPOSTs)
        {
            try
            {
                requestResponse = new();

                foreach (var masterPOST in masterPOSTs)
                {
                    var task = Create(masterPOST);
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

        public async Task<RequestResponse> Create(StatePOST masterPOST)
        {
            try
            {
                await using var transaction = await context.Database.BeginTransactionAsync();
                var isExists = await context.States.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

                if (isExists == false)
                {
                    State masterData = new();
                    //masterData.MenuModuleId = masterPOST.MenuModuleId;
                    masterData.CountryId = masterPOST.CountryId;
                    //masterData.StatusTypeId = masterPOST.StatusTypeId;
                    //masterData.LanguageId = masterPOST.LanguageId;
                    masterData.Code = masterPOST.Code;
                    masterData.Name = masterPOST.Name;
                    masterData.IsDefault = masterPOST.IsDefault;
                    masterData.IsDraft = masterPOST.IsDraft;

                    await context.States.AddAsync(masterData);
                    //await context.SaveChangesAsync();

                    StateHistory history = new();
                    history.StateId = masterData.Id;
                    //history.MenuModuleId = masterPOST.MenuModuleId;
                    history.CountryId = masterPOST.CountryId;
                    //history.LanguageId = masterPOST.LanguageId;
                    //history.ActionTypeId = masterPOST.ActionTypeId;
                    //history.ExportTypeId = masterPOST.ExportTypeId;
                    //history.ExportTo = masterPOST.ExportTo;
                    //history.SourceURL = masterPOST.SourceURL;
                    history.Code = masterPOST.Code;
                    history.Name = masterPOST.Name;
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

                    await context.StateHistory.AddAsync(history);
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
                var ishistoryExists = await context.StateHistory.AsNoTracking().AnyAsync(x => x.StateId == id);

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
                    await context.StateHistory.Where(x => x.StateId == id).ExecuteDeleteAsync();
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

        public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
        {
            try
            {
                GetAllDTO result = new();

                var data = (from s in context.States
                            join mm in context.MenuModules on s.CountryId equals mm.Id
                            join c in context.Countries on s.CountryId equals c.Id
                            //join st in context.StatusTypes on s.StatusTypeId equals st.Id
                            //join l in context.Languages on s.LanguageId equals l.Id
                            
                            select new
                            {
                                s.Id,
                                Menu = mm.Name,
                                Country = c.Name,
                                //Status = st.Name,
                                //Language = l.Name,
                                s.Name,
                                s.Code,
                                s.IsDefault,  
                                s.IsDraft  
                            }).AsNoTracking().AsQueryable();

                if (skip == 0 || take == 0)
                {
                    result.Count = await shared.GetCounts<State>(pageSize);
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
                    result.Count = await shared.GetCounts<State>(pageSize);
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
                var data = (from sa in context.StateHistory
                            join s in context.States on sa.StateId equals s.Id
                            //join mm in context.MenuModules on sa.MenuModuleId equals mm.Id
                            join c in context.Countries on sa.CountryId equals c.Id
                            join at in context.ActionTypes on sa.ActionTypeId equals at.Id
                            //join l in context.Languages on sa.LanguageId equals l.Id
                            //join et in context.ExportTypes on sa.ExportTypeId equals et.Id
                            select new
                            {
                                sa.Id,
                                State = s.Name,
                                //MenuModule = mm.Name,
                                Country = c.Name,
                                //Language = l.Name,
                                Action = at.Name,
                                //ExportType = et.Name,
                                //sa.ExportTo,
                                //sa.SourceURL,
                                sa.Code,
                                sa.Name,
                                sa.IsDefault,
                                sa.IsDraft,
                                //sa.Browser,
                                //sa.Location,
                                //sa.DeviceIP,
                                //sa.LocationURL,
                                //sa.DeviceName,
                                //sa.Latitude,
                                //sa.Longitude,
                                //sa.ActionBy,
                                //sa.ActionAt
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

        public Task<RequestResponse> GetTemplate()
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> SoftDelete(int id)
        {
            var result = await shared.SoftDelete<State>(id);
            return result;
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
                    //.SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                    .SetProperty(x => x.CountryId, masterPUT.CountryId)
                    //.SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                    //.SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                    .SetProperty(x => x.Code, masterPUT.Code)
                    .SetProperty(x => x.Name, masterPUT.Name)
                    .SetProperty(x => x.IsDefault, masterPUT.IsDefault)
                    .SetProperty(x => x.IsDraft, masterPUT.IsDraft));

                    StateHistory history = new();
                    history.StateId = masterPUT.Id;
                    //history.MenuModuleId = masterPUT.MenuModuleId;
                    history.CountryId = masterPUT.CountryId;
                    //history.LanguageId = masterPUT.LanguageId;
                    //history.ActionTypeId = masterPUT.ActionTypeId;
                    //history.ExportTypeId = masterPUT.ExportTypeId;
                    //history.ExportTo = masterPUT.ExportTo;
                    //history.SourceURL = masterPUT.SourceURL;
                    history.Code = masterPUT.Code;
                    history.Name = masterPUT.Name;
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

                    await context.StateHistory.AddAsync(history);
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

        Task<RequestResponse> IBase<StatePOST, StatePUT>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> Lookup()
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> Restore(int id)
        {
            throw new NotImplementedException();
        }
    }
}
