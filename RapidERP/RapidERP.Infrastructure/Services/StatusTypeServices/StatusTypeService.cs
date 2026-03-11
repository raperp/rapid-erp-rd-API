using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.ActionTypeDTOs;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.StatusTypeDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services.StatusTypeServices;

public class StatusTypeService(IRepository repository) : IStatusTypeService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> Create(StatusTypePOST masterPOST)
    {
        try
        {
            //using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByName<StatusType>(masterPOST.Name);

            ActionDTO actionDTO = new();
            actionDTO.CreatedAt = (masterPOST.IsDraft == false) ? DateTime.UtcNow : null;
            actionDTO.DraftedAt = (masterPOST.IsDraft == true) ? DateTime.UtcNow : null;
            actionDTO.UpdatedAt = null;
            actionDTO.DeletedAt = null;

            if (isExists == false)
            {
                StatusType masterData = new();
                masterData.Description = masterPOST.Description;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.DefaultLanguageId = masterPOST.DefaultLanguageId;
                masterData.Name = masterPOST.Name;
                masterData.Code = masterPOST.Code;
                masterData.CreatedAt = actionDTO.CreatedAt;
                masterData.DraftedAt = actionDTO.DraftedAt;
                masterData.UpdatedAt = actionDTO.UpdatedAt;
                masterData.DeletedAt = actionDTO.DeletedAt;
                masterData.IsDefault = masterPOST.IsDefault;
                masterData.IsDraft = masterPOST.IsDraft;

                await repository.Add(masterData);

                //transaction.Commit();

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
                //var localizations = await repository.Set<LanguageLocalization>().Where(c => c.CountryId == id).Select(x => x.Id).ToListAsync(); 

                //foreach (var item in localizations)
                //{
                //    await repository.Delete<CountryLocalization>(item);
                //}

                await repository.Delete<StatusType>(id);

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
            var data = (from st in repository.Set<StatusType>()
                        join l in repository.Set<Language>() on st.LanguageId equals l.Id
                        join dl in repository.Set<Language>() on st.DefaultLanguageId equals dl.Id
                        select new
                        {
                            st.Id,
                            st.Name,
                            st.Description,
                            st.Code,
                            st.IsDefault,
                            st.IsDraft
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

    public async Task<RequestResponse> GetById(int id)
    {
        try
        {
            var data = (from et in repository.Set<StatusType>()
                        join l in repository.Set<Language>() on et.LanguageId equals l.Id
                        join dl in repository.Set<Language>() on et.DefaultLanguageId equals dl.Id
                        select new
                        {
                            et.Id,
                            et.Name,
                            et.Description,
                            et.Code,
                            et.IsDefault,
                            et.IsDraft
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

    public async Task<RequestResponse> Import(List<StatusTypePUT> imports)
    {
        try
        {
            foreach (var import in imports)
            {
                if (import.Id == 0)
                {
                    StatusTypePOST masterData = new();
                    masterData.Description = import.Description;
                    masterData.LanguageId = import.LanguageId;
                    masterData.DefaultLanguageId = import.DefaultLanguageId;
                    masterData.Name = import.Name;
                    masterData.Code = import.Code;
                    masterData.IsDefault = import.IsDefault;
                    masterData.IsDraft = import.IsDraft;

                    var result = await Create(masterData);

                    requestResponse.Message = result.Message;
                    requestResponse.IsSuccess = result.IsSuccess;
                    requestResponse.StatusCode = result.StatusCode;
                    requestResponse.Data = result.Data;
                }

                else
                {
                    StatusTypePUT masterData = new();
                    masterData.Id = import.Id;
                    masterData.Description = import.Description;
                    masterData.LanguageId = import.LanguageId;
                    masterData.DefaultLanguageId = import.DefaultLanguageId;
                    masterData.Name = import.Name;
                    masterData.Code = import.Code;
                    masterData.IsDefault = import.IsDefault;
                    masterData.IsDraft = import.IsDraft;

                    var result = await Update(masterData);

                    requestResponse.Message = result.Message;
                    requestResponse.IsSuccess = result.IsSuccess;
                    requestResponse.StatusCode = result.StatusCode;
                    requestResponse.Data = result.Data;
                }
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

    public Task<RequestResponse> Lookup()
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> Update(StatusTypePUT masterPUT)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus)
    {
        throw new NotImplementedException();
    }

    //public async Task<RequestResponse> CreateBulk(List<StatusTypePOST> masterPOSTs)
    //{
    //    try
    //    {
    //        requestResponse = new();

    //        foreach (var masterPOST in masterPOSTs)
    //        {
    //            var task = Create(masterPOST);
    //            var result = await Task.WhenAll(task);
    //            requestResponse.Message = result.FirstOrDefault().Message;
    //            requestResponse.IsSuccess = result.FirstOrDefault().IsSuccess;
    //            requestResponse.StatusCode = result.FirstOrDefault().StatusCode;
    //            requestResponse.Data = result.FirstOrDefault().Data;
    //        }

    //        //requestResponse = new()
    //        //{
    //        //    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
    //        //    IsSuccess = true,
    //        //    Message = ResponseMessage.CreateSuccess,
    //        //    Data = masterPOSTs
    //        //};

    //        return requestResponse;
    //    }

    //    catch
    //    {
    //        requestResponse = new()
    //        {
    //            StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
    //            IsSuccess = false,
    //            Message = ResponseMessage.WrongDataInput
    //        };

    //        return requestResponse;
    //    }
    //}

    //public async Task<RequestResponse> Create(StatusTypePOST masterPOST)
    //{
    //    try
    //    {
    //        await using var transaction = await context.Database.BeginTransactionAsync();
    //        var isExists = await context.StatusTypes.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

    //        if (isExists == false)
    //        {
    //            StatusType masterData = new();
    //            //masterData.LanguageId = masterPOST.LanguageId;
    //            masterData.Name = masterPOST.Name;
    //            masterData.Description = masterPOST.Description;

    //            await context.StatusTypes.AddAsync(masterData);
    //            await context.SaveChangesAsync();

    //            StatusTypeHistory history = new();
    //            history.StatusTypeId = masterData.Id;
    //            //history.LanguageId = masterPOST.LanguageId;
    //            history.ActionTypeId = masterPOST.ActionTypeId;
    //            //history.ExportTypeId = masterPOST.ExportTypeId;
    //            //history.ExportTo = masterPOST.ExportTo;
    //            //history.SourceURL = masterPOST.SourceURL;
    //            history.Name = masterPOST.Name;
    //            history.Description = masterPOST.Description;
    //            //history.Browser = masterPOST.Browser;
    //            //history.Location = masterPOST.Location;
    //            //history.DeviceIP = masterPOST.DeviceIP;
    //            //history.LocationURL = masterPOST.LocationURL;
    //            //history.DeviceName = masterPOST.DeviceName;
    //            //history.Latitude = masterPOST.Latitude;
    //            //history.Longitude = masterPOST.Longitude;
    //            //history.ActionBy = masterPOST.ActionBy;
    //            //history.ActionAt = DateTime.Now;

    //            await context.StatusTypeHistory.AddAsync(history);
    //            await context.SaveChangesAsync();
    //            await transaction.CommitAsync();

    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
    //                IsSuccess = true,
    //                Message = ResponseMessage.CreateSuccess,
    //                Data = masterPOST
    //            };
    //        }

    //        else
    //        {
    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
    //                IsSuccess = false,
    //                Message = $"{ResponseMessage.RecordExists} {masterPOST.Name}"
    //            };
    //        }

    //        return requestResponse;
    //    }

    //    catch
    //    {
    //        requestResponse = new()
    //        {
    //            StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
    //            IsSuccess = false,
    //            Message = ResponseMessage.WrongDataInput
    //        };

    //        return requestResponse;
    //    }
    //}

    //public async Task<RequestResponse> Delete(int id)
    //{
    //    try
    //    {
    //        //await using var transaction = await context.Database.BeginTransactionAsync();
    //        //var ishistoryExists = await context.StatusTypehistorys.AsNoTracking().AnyAsync(x => x.StatusTypeId == id);

    //        //if (ishistoryExists == false)
    //        //{
    //        //    requestResponse = new()
    //        //    {
    //        //        StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
    //        //        IsSuccess = false,
    //        //        Message = ResponseMessage.NoRecordFound
    //        //    };
    //        //}

    //        //else
    //        //{
    //        //    await context.StatusTypehistorys.Where(x => x.StatusTypeId == id).ExecuteDeleteAsync();
    //        //}

    //        //var isExists = await context.StatusTypes.AsNoTracking().AnyAsync(x => x.Id == id);

    //        //if (isExists == false)
    //        //{
    //        //    requestResponse = new()
    //        //    {
    //        //        StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
    //        //        IsSuccess = false,
    //        //        Message = ResponseMessage.NoRecordFound
    //        //    };
    //        //}

    //        //else
    //        //{
    //        //    await context.StatusTypes.Where(x => x.Id == id).ExecuteDeleteAsync();
    //        //    await transaction.CommitAsync();
    //        //}

    //        //requestResponse = new()
    //        //{
    //        //    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
    //        //    IsSuccess = true,
    //        //    Message = ResponseMessage.DeleteSuccess
    //        //};

    //        return requestResponse;
    //    }

    //    catch (Exception ex)
    //    {
    //        requestResponse = new()
    //        {
    //            StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
    //            IsSuccess = false,
    //            Message = ex.Message
    //        };

    //        return requestResponse;
    //    }
    //}

    //public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    //{
    //    try
    //    {
    //        var data = (from st in context.StatusTypes
    //                    //join l in context.Languages on st.LanguageId equals l.Id
    //                    select new
    //                    {
    //                        st.Id,
    //                        //Language = l.Name,
    //                        st.Name,
    //                        st.Description
    //                    }).AsNoTracking().AsQueryable();

    //        if (skip == 0 || take == 0)
    //        {
    //            var result = await data.ToListAsync();

    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
    //                IsSuccess = true,
    //                Message = ResponseMessage.FetchSuccess,
    //                Data = result
    //            };
    //        }

    //        else
    //        {
    //            var result = await data.Skip(skip).Take(take).ToListAsync();

    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
    //                IsSuccess = true,
    //                Message = ResponseMessage.FetchSuccessWithPagination,
    //                Data = result
    //            };
    //        }

    //        return requestResponse;
    //    }

    //    catch (Exception ex)
    //    {
    //        requestResponse = new()
    //        {
    //            StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
    //            IsSuccess = false,
    //            Message = ex.Message
    //        };

    //        return requestResponse;
    //    }
    //}

    //public Task<RequestResponse> GetAll(int skip, int take)
    //{
    //    throw new NotImplementedException();
    //}

    //public async Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    //{
    //    try
    //    {
    //        var data = (from sta in context.StatusTypeHistory
    //                    join st in context.StatusTypes on sta.StatusTypeId equals st.Id
    //                    join at in context.ActionTypes on sta.ActionTypeId equals at.Id
    //                    //join l in context.Languages on sta.LanguageId equals l.Id
    //                    //join et in context.ExportTypes on sta.ExportTypeId equals et.Id
    //                    select new 
    //                    {
    //                        sta.Id,
    //                        Status = st.Name,
    //                        //Language = l.Name,
    //                        Action = at.Name,
    //                        //ExportType = et.Name,
    //                        //sta.ExportTo,
    //                        //sta.SourceURL,
    //                        sta.Name,
    //                        sta.Description,
    //                        //sta.Browser,
    //                        //sta.Location,
    //                        //sta.DeviceIP,
    //                        //sta.LocationURL,
    //                        //sta.DeviceName,
    //                        //sta.Latitude,
    //                        //sta.Longitude,
    //                        //sta.ActionBy,
    //                        //sta.ActionAt
    //                    }).AsNoTracking().AsQueryable();

    //        if (skip == 0 || take == 0)
    //        {
    //            var result = await data.ToListAsync();

    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
    //                IsSuccess = true,
    //                Message = ResponseMessage.FetchSuccess,
    //                Data = result
    //            };
    //        }

    //        else
    //        {
    //            var result = await data.Skip(skip).Take(take).ToListAsync();

    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
    //                IsSuccess = true,
    //                Message = ResponseMessage.FetchSuccessWithPagination,
    //                Data = result
    //            };
    //        }

    //        return requestResponse;
    //    }

    //    catch (Exception ex)
    //    {
    //        requestResponse = new()
    //        {
    //            StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
    //            IsSuccess = false,
    //            Message = ex.Message
    //        };

    //        return requestResponse;
    //    }
    //}

    //public async Task<dynamic> GetSingle(int id)
    //{
    //    var result = await shared.GetSingle<StatusType>(id);
    //    return result;
    //}

    //public Task<RequestResponse> GetTemplate()
    //{
    //    throw new NotImplementedException();
    //}

    //public async Task<dynamic> SoftDelete(int id)
    //{
    //    var result = "Not Applicable";
    //    return result;
    //}

    //public async Task<RequestResponse> Update(StatusTypePUT masterPUT)
    //{
    //    try
    //    {
    //        await using var transaction = await context.Database.BeginTransactionAsync();
    //        var isExists = await context.StatusTypes.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

    //        if (isExists == false)
    //        {
    //            //ActionDTO actionDTO = new();
    //            //actionDTO.UpdatedBy = (masterPUT.IsDraft == false) ? masterPUT.ActionBy : null;
    //            //actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.Now : null;
    //            //actionDTO.DraftedBy = (masterPUT.IsDraft == true) ? masterPUT.ActionBy : null;
    //            //actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.Now : null;

    //            await context.StatusTypes.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
    //            //.SetProperty(x => x.LanguageId, masterPUT.LanguageId)
    //            .SetProperty(x => x.Name, masterPUT.Name)
    //            .SetProperty(x => x.Description, masterPUT.Description));

    //            StatusTypeHistory history = new();
    //            history.StatusTypeId = masterPUT.Id;
    //            //history.LanguageId = masterPUT.LanguageId;
    //            history.ActionTypeId = masterPUT.ActionTypeId;
    //            //history.ExportTypeId = masterPUT.ExportTypeId;
    //            //history.ExportTo = masterPUT.ExportTo;
    //            //history.SourceURL = masterPUT.SourceURL;
    //            history.Name = masterPUT.Name;
    //            history.Description = masterPUT.Description;
    //            //history.Browser = masterPUT.Browser;
    //            //history.Location = masterPUT.Location;
    //            //history.DeviceIP = masterPUT.DeviceIP;
    //            //history.LocationURL = masterPUT.LocationURL;
    //            //history.DeviceName = masterPUT.DeviceName;
    //            //history.Latitude = masterPUT.Latitude;
    //            //history.Longitude = masterPUT.Longitude;
    //            //history.ActionBy = masterPUT.ActionBy;
    //            //history.ActionAt = DateTime.Now;

    //            await context.StatusTypeHistory.AddAsync(history);
    //            await context.SaveChangesAsync();
    //            await transaction.CommitAsync();

    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
    //                IsSuccess = true,
    //                Message = ResponseMessage.UpdateSuccess,
    //                Data = masterPUT
    //            };
    //        }

    //        else
    //        {
    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
    //                IsSuccess = false,
    //                Message = ResponseMessage.RecordExists
    //            };
    //        }

    //        return requestResponse;
    //    }

    //    catch
    //    {
    //        requestResponse = new()
    //        {
    //            StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
    //            IsSuccess = false,
    //            Message = ResponseMessage.WrongDataInput
    //        };

    //        return requestResponse;
    //    }
    //}

    //public Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus)
    //{
    //    throw new NotImplementedException();
    //}

    //Task<RequestResponse> IBase<StatusTypePOST, StatusTypePUT>.GetById(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<RequestResponse> Lookup()
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<RequestResponse> Restore(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<RequestResponse> Import(List<CountryImport> imports)
    //{
    //    throw new NotImplementedException();
    //}
}
