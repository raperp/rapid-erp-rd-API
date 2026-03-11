using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.ExportTypeDTOs;
using RapidERP.Application.DTOs.LanguageDTOs.LanguageMaster;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services.ExportTypeServices;
public class ExportTypeService(IRepository repository) : IExportTypeService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> Create(ExportTypePOST masterPOST)
    {
        try
        {
            //using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByName<ExportType>(masterPOST.Name);

            ActionDTO actionDTO = new();
            actionDTO.CreatedAt = (masterPOST.IsDraft == false) ? DateTime.UtcNow : null;
            actionDTO.DraftedAt = (masterPOST.IsDraft == true) ? DateTime.UtcNow : null;
            actionDTO.UpdatedAt = null;
            actionDTO.DeletedAt = null;

            if (isExists == false)
            {
                ExportType masterData = new();
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

                await repository.Delete<ExportType>(id);

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
            var data = (from et in repository.Set<ExportType>()
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
            var data = (from et in repository.Set<ExportType>()
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

    public async Task<RequestResponse> Import(List<ExportTypePUT> imports)
    {
        try
        {
            foreach (var import in imports)
            {
                if (import.Id == 0)
                {
                    ExportTypePOST masterData = new();
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
                    ExportTypePUT masterData = new();
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
            var data = (from et in repository.Set<ExportType>()
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

    public async Task<RequestResponse> Update(ExportTypePUT masterPUT)
    {
        try
        {
            //using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByIdName<ExportType>(masterPUT.Id, masterPUT.Name);
            var masterRecord = await repository.FindById<ExportType>(masterPUT.Id);

            ActionDTO actionDTO = new();
            actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.UtcNow : null;
            actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.UtcNow : null;

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                masterPUT.Name = (masterPUT.Name is not null) ? masterPUT.Name : masterRecord.Name;
                masterPUT.Description = (masterPUT.Description is not null) ? masterPUT.Description : masterRecord.Description;
                masterPUT.Code = (masterPUT.Code is not null) ? masterPUT.Code : masterRecord.Code;
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

    public Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus)
    {
        throw new NotImplementedException();
    }

    //public async Task<RequestResponse> CreateBulk(List<ExportTypePOST> masterPOSTs)
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

    //public async Task<RequestResponse> Create(ExportTypePOST masterPOST)
    //{
    //    try
    //    {
    //        await using var transaction = await context.Database.BeginTransactionAsync();
    //        var isExists = await context.ExportTypes.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

    //        if (isExists == false)
    //        {
    //            ExportType masterData = new();
    //            //masterData.LanguageId = masterPOST.LanguageId;
    //            masterData.Name = masterPOST.Name;
    //            masterData.Description = masterPOST.Description;

    //            await context.ExportTypes.AddAsync(masterData);
    //            await context.SaveChangesAsync();

    //            ExportTypeHistory history = new();
    //            history.ExportTypeId = masterData.Id;
    //            //history.LanguageId = masterPOST.LanguageId;
    //            history.Name = masterData.Name;
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

    //            await context.ExportTypeHistory.AddAsync(history);
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
    //        var ishistoryExists = await context.ExportTypeHistory.AsNoTracking().AnyAsync(x => x.ExportTypeId == id);

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
    //            await context.ExportTypeHistory.Where(x => x.ExportTypeId == id).ExecuteDeleteAsync();
    //        }

    //        var isExists = await context.ExportTypes.AsNoTracking().AnyAsync(x => x.Id == id);

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
    //            await context.ExportTypes.Where(x => x.Id == id).ExecuteDeleteAsync();
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
    //        var data = (from et in context.ExportTypes
    //                    //join l in context.Languages on et.LanguageId equals l.Id
    //                    select new
    //                    {
    //                        et.Id,
    //                        //Language = l.Name,
    //                        et.Name,
    //                        et.Description
    //                    }).AsNoTracking().AsQueryable();

    //        if (skip == 0 || take == 0)
    //        {
    //            var result = await data.ToListAsync() ;

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
    //        var data = (from eta in context.ExportTypeHistory
    //                    join et in context.ExportTypes on eta.ExportTypeId equals et.Id
    //                    //join l in context.Languages on eta.LanguageId equals l.Id
    //                    select new
    //                    {
    //                        eta.Id,
    //                        ExportType = et.Name,
    //                        //Language = l.Name,
    //                        eta.Name,
    //                        eta.Description,
    //                        //eta.Browser,
    //                        //eta.Location,
    //                        //eta.DeviceIP,
    //                        //eta.LocationURL,
    //                        //eta.DeviceName,
    //                        //eta.Latitude,
    //                        //eta.Longitude,
    //                        //eta.ActionBy,
    //                        //eta.ActionAt
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
    //    var result = await shared.GetSingle<ExportType>(id);
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

    //public async Task<RequestResponse> Update(ExportTypePUT masterPUT)
    //{
    //    try
    //    {
    //        await using var transaction = await context.Database.BeginTransactionAsync();
    //        var isExists = await context.ExportTypes.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

    //        if (isExists == false)
    //        {
    //            //ActionDTO actionDTO = new();
    //            //actionDTO.UpdatedBy = (masterPUT.IsDraft == false) ? masterPUT.ActionBy : null;
    //            //actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.Now : null;
    //            //actionDTO.DraftedBy = (masterPUT.IsDraft == true) ? masterPUT.ActionBy : null;
    //            //actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.Now : null;

    //            await context.ExportTypes.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
    //            //.SetProperty(x => x.LanguageId, masterPUT.LanguageId)
    //            .SetProperty(x => x.Name, masterPUT.Name)
    //            .SetProperty(x => x.Description, masterPUT.Description));

    //            ExportTypeHistory history = new();
    //            history.ExportTypeId = masterPUT.Id;
    //            //history.LanguageId = masterPUT.LanguageId;
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

    //            await context.ExportTypeHistory.AddAsync(history);
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

    //Task<RequestResponse> IBase<ExportTypePOST, ExportTypePUT>.GetById(int id)
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
