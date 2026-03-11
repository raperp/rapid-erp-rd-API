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
                    ActionTypePUT masterData = new();
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
                masterPUT.LanguageId = (masterPUT.LanguageId is not null) ? masterPUT.LanguageId : masterRecord.LanguageId;
                masterPUT.DefaultLanguageId = (masterPUT.DefaultLanguageId is not null) ? masterPUT.DefaultLanguageId : masterRecord.DefaultLanguageId;
                masterPUT.Name = (masterPUT.Name is not null) ? masterPUT.Name : masterRecord.Name;
                masterPUT.Code = (masterPUT.Code is not null) ? masterPUT.Code : masterRecord.Code;
                masterPUT.IsDefault = (masterPUT.IsDefault is not null) ? masterPUT.IsDefault : masterRecord.IsDefault;
                masterPUT.IsDraft = (masterPUT.IsDraft is not null) ? masterPUT.IsDraft : masterRecord.IsDraft;
            }

            if (isExists == false)
            {
                 
                masterRecord.Description = masterPUT.Description;
                masterRecord.LanguageId = masterPUT.LanguageId;
                masterRecord.DefaultLanguageId = masterPUT.DefaultLanguageId;
                masterRecord.Name = masterPUT.Name;
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
