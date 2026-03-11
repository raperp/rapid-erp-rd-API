using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.ActionTypeDTOs;
using RapidERP.Application.DTOs.ExportTypeDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services.ActionTypeServices;

public class ActionTypeService(IRepository repository) : IActionTypeService
{
    RequestResponse requestResponse { get; set; }

    //public async Task<RequestResponse> CreateBulk(List<ActionTypePOST> masterPOSTs)
    //{
    //    try
    //    {
    //        requestResponse = new();

    //        foreach (var masterPOST in masterPOSTs)
    //        {
    //            var task = CreateSingle(masterPOST);
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

    //public async Task<RequestResponse> CreateSingle(ActionTypePOST masterPOST)
    //{
    //    try
    //    {
    //        await using var transaction = await context.Database.BeginTransactionAsync();
    //        var isExists = await context.ActionTypes.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

    //        if (isExists == false)
    //        {
    //            ActionType masterData = new();
    //            //masterData.LanguageId = masterPOST.LanguageId;
    //            masterData.Name = masterPOST.Name;
    //            masterData.Description = masterPOST.Description;

    //            await context.ActionTypes.AddAsync(masterData);
    //            await context.SaveChangesAsync();

    //            ActionTypeHistory history = new();
    //            history.ActionTypeId = masterData.Id;
    //            //history.LanguageId = masterPOST.LanguageId;
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

    //            await context.ActionTypeHistory.AddAsync(history);
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
    //        await using var transaction = await context.Database.BeginTransactionAsync();
    //        var ishistoryExists = await context.ActionTypeHistory.AsNoTracking().AnyAsync(x => x.ActionTypeId == id);

    //        if (ishistoryExists == false)
    //        {
    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
    //                IsSuccess = false,
    //                Message = ResponseMessage.NoRecordFound
    //            };
    //        }

    //        else
    //        {
    //            await context.ActionTypeHistory.Where(x => x.ActionTypeId == id).ExecuteDeleteAsync();
    //        }

    //        var isExists = await context.ActionTypes.AsNoTracking().AnyAsync(x => x.Id == id);

    //        if (isExists == false)
    //        {
    //            requestResponse = new()
    //            {
    //                StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
    //                IsSuccess = false,
    //                Message = ResponseMessage.NoRecordFound
    //            };
    //        }

    //        else
    //        {
    //            await context.ActionTypes.Where(x => x.Id == id).ExecuteDeleteAsync();
    //            await transaction.CommitAsync();
    //        }

    //        requestResponse = new()
    //        {
    //            StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
    //            IsSuccess = true,
    //            Message = ResponseMessage.DeleteSuccess
    //        };

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
    //        var data = (from at in context.ActionTypes
    //                    //join l in context.Languages on at.LanguageId equals l.Id
    //                    select new
    //                    {
    //                        at.Id,
    //                        //Language = l.Name,
    //                        at.Name,
    //                        at.Description
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
    //        var data = (from ath in context.ActionTypeHistory
    //                    join at in context.ActionTypes on ath.ActionTypeId equals at.Id
    //                    //join l in context.Languages on ath.LanguageId equals l.Id
    //                    //join et in context.ExportTypes on ath.ExportTypeId equals et.Id
    //                    select new
    //                    {
    //                        ath.Id,
    //                        ActionType = at.Name,
    //                        //Language = l.Name,
    //                        //ExportType = et.Name,
    //                        //ath.ExportTo,
    //                        //ath.SourceURL,
    //                        ath.Name,
    //                        ath.Description,
    //                        //ath.Browser,
    //                        //ath.Location,
    //                        //ath.DeviceIP,
    //                        //ath.LocationURL,
    //                        //ath.DeviceName,
    //                        //ath.Latitude,
    //                        //ath.Longitude,
    //                        //ath.ActionBy,
    //                        //ath.ActionAt
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
    //    var result = await shared.GetSingle<ActionType>(id);
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

    //public async Task<RequestResponse> Update(ActionTypePUT masterPUT)
    //{
    //    try
    //    {
    //        await using var transaction = await context.Database.BeginTransactionAsync();
    //        var isExists = await context.ActionTypes.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

    //        if (isExists == false)
    //        {
    //            //ActionDTO actionDTO = new();
    //            //actionDTO.UpdatedBy = (masterPUT.IsDraft == false) ? masterPUT.ActionBy : null;
    //            //actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.Now : null;
    //            //actionDTO.DraftedBy = (masterPUT.IsDraft == true) ? masterPUT.ActionBy : null;
    //            //actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.Now : null;

    //            await context.ActionTypes.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
    //            //.SetProperty(x => x.LanguageId, masterPUT.LanguageId)
    //            .SetProperty(x => x.Name, masterPUT.Name)
    //            .SetProperty(x => x.Description, masterPUT.Description));

    //            ActionTypeHistory history = new();
    //            history.ActionTypeId = masterPUT.Id;
    //            //history.LanguageId = masterPUT.LanguageId;
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

    //            await context.ActionTypeHistory.AddAsync(history);
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



    //Task<RequestResponse> IBase<ActionTypePOST, ActionTypePUT>.Create(ActionTypePOST masterPOST)
    //{
    //    throw new NotImplementedException();
    //}

    //Task<RequestResponse> IBase<ActionTypePOST, ActionTypePUT>.Delete(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //Task<RequestResponse> IBase<ActionTypePOST, ActionTypePUT>.GetAll(int skip, int take)
    //{
    //    throw new NotImplementedException();
    //}

    ////Task<RequestResponse> IBase<ActionTypePOST, ActionTypePUT>.GetHistory()
    ////{
    ////    throw new NotImplementedException();
    ////}

    //Task<RequestResponse> IBase<ActionTypePOST, ActionTypePUT>.GetById(int id)
    //{
    //    throw new NotImplementedException();
    //}





    //Task<RequestResponse> IBase<ActionTypePOST, ActionTypePUT>.Update(ActionTypePUT masterPUT)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus)
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
    public async Task<RequestResponse> Create(ActionTypePOST masterPOST)
    {
        try
        {
            //using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByName<Language>(masterPOST.Name);

            ActionDTO actionDTO = new();
            actionDTO.CreatedAt = (masterPOST.IsDraft == false) ? DateTime.UtcNow : null;
            actionDTO.DraftedAt = (masterPOST.IsDraft == true) ? DateTime.UtcNow : null;
            actionDTO.UpdatedAt = null;
            actionDTO.DeletedAt = null;

            if (isExists == false)
            {
                ActionType masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.Description = masterPOST.Description;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.DefaultLanguageId = masterPOST.DefaultLanguageId;
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

                await repository.Delete<ActionType>(id);

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
            var data = (from at in repository.Set<ActionType>()
                        join l in repository.Set<Language>() on at.LanguageId equals l.Id
                        join dl in repository.Set<Language>() on at.DefaultLanguageId equals dl.Id
                        select new
                        {
                            at.Id,
                            at.Name,
                            at.Description,
                            at.Code,
                            at.IsDefault,
                            at.IsDraft
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
            var data = (from et in repository.Set<ActionType>()
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

    public async Task<RequestResponse> Import(List<ActionTypePUT> imports)
    {
        try
        {
            foreach (var import in imports)
            {
                if (import.Id == 0)
                {
                    ActionTypePOST masterData = new();
                    masterData.Name = import.Name;
                    masterData.Description = import.Description;
                    masterData.LanguageId = import.LanguageId;
                    masterData.DefaultLanguageId = import.DefaultLanguageId;
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
                    ActionTypePUT masterData = new();
                    masterData.Id = import.Id;
                    masterData.Name = import.Name;
                    masterData.Description = import.Description;
                    masterData.LanguageId = import.LanguageId;
                    masterData.DefaultLanguageId = import.DefaultLanguageId;
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

    public async Task<RequestResponse> Lookup()
    {
        try
        {
            var data = (from et in repository.Set<ActionType>()
                        select new
                        {
                            et.Id,
                            et.Name,
                            et.Description,
                            et.Code
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

    public async Task<RequestResponse> Update(ActionTypePUT masterPUT)
    {
        try
        {
            //using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByIdName<ActionType>(masterPUT.Id, masterPUT.Name);
            var masterRecord = await repository.FindById<ActionType>(masterPUT.Id);

            ActionDTO actionDTO = new();
            actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.UtcNow : null;
            actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.UtcNow : null;

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                masterPUT.Description = (masterPUT.Description is not null) ? masterPUT.Description : masterRecord.Description;
                masterPUT.Name = (masterPUT.Name is not null) ? masterPUT.Name : masterRecord.Name;
                masterPUT.Code = (masterPUT.Code is not null) ? masterPUT.Code : masterRecord.Code;
                masterPUT.LanguageId = (masterPUT.LanguageId is not null) ? masterPUT.LanguageId : masterRecord.LanguageId;
                masterPUT.DefaultLanguageId = (masterPUT.DefaultLanguageId is not null) ? masterPUT.DefaultLanguageId : masterRecord.DefaultLanguageId;
                masterPUT.IsDefault = (masterPUT.IsDefault is not null) ? masterPUT.IsDefault : masterRecord.IsDefault;
                masterPUT.IsDraft = (masterPUT.IsDraft is not null) ? masterPUT.IsDraft : masterRecord.IsDraft;
            }

            if (isExists == false)
            {
                masterRecord.Name = masterPUT.Name;
                masterRecord.Description = masterPUT.Description;
                masterRecord.LanguageId = masterPUT.LanguageId;
                masterRecord.DefaultLanguageId = masterPUT.DefaultLanguageId;
                masterRecord.Code = masterPUT.Code;
                masterRecord.DraftedAt = actionDTO.DraftedAt;
                masterRecord.UpdatedAt = actionDTO.UpdatedAt;
                masterRecord.IsDefault = masterPUT.IsDefault;
                masterRecord.IsDraft = masterPUT.IsDraft;
                
                await repository.Update(masterRecord);

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

    public async Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus)
    {
        throw new NotImplementedException();
    }
}
