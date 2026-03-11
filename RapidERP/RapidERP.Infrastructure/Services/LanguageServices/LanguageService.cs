using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.LanguageDTOs.LanguageMaster;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services.LanguageServices;

public class LanguageService(IRepository repository) : ILanguageService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> Create(LanguagePOST masterPOST)
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
                Language masterData = new();
                masterData.ISONumeric = masterPOST.ISONumeric;
                masterData.Name = masterPOST.Name;
                masterData.ISO2Code = masterPOST.ISO2Code;
                masterData.ISO3Code = masterPOST.ISO3Code;
                masterData.IconURL = masterPOST.IconURL;
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

                await repository.Delete<Language>(id);

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
            GetAllDTO result = new();

            var data = (from l in repository.Set<Language>()
                        select new
                        {
                            l.Id,
                            l.ISONumeric,
                            l.Name,
                            l.ISO2Code,
                            l.ISO3Code,
                            l.IconURL
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                //result.Count = await repository.GetCounts<Language>();
                result.Data = await data.ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result.Data
                };
            }

            else
            {
                //result.Count = await repository.GetCounts<Language>();
                result.Data = await data.Skip(skip).Take(take).ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result.Data
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
            var data = (from l in repository.Set<Language>()
                        select new
                        {
                            l.Id,
                            l.ISONumeric,
                            l.Name,
                            l.ISO2Code,
                            l.ISO3Code,
                            l.IconURL
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

    public async Task<RequestResponse> Import(List<LanguagePUT> imports)
    {
        try
        {
            foreach (var import in imports)
            {
                if (import.Id == 0)
                {
                    LanguagePOST masterData = new();
                    masterData.ISONumeric = import.ISONumeric;
                    masterData.Name = import.Name;
                    masterData.ISO2Code = import.ISO2Code;
                    masterData.ISO3Code = import.ISO3Code;
                    masterData.IconURL = import.IconURL;
                    masterData.Code = import.Code;

                    var result = await Create(masterData);
                    
                    requestResponse.Message = result.Message;
                    requestResponse.IsSuccess = result.IsSuccess;
                    requestResponse.StatusCode = result.StatusCode;
                    requestResponse.Data = result.Data;
                }

                else
                {
                    LanguagePUT masterData = new();
                    masterData.Id = import.Id;
                    masterData.ISONumeric = import.ISONumeric;
                    masterData.Name = import.Name;
                    masterData.ISO2Code = import.ISO2Code;
                    masterData.ISO3Code = import.ISO3Code;
                    masterData.IconURL = import.IconURL;
                    masterData.Code = import.Code;

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
            var data = (from l in repository.Set<Language>()
                        select new
                        {
                            l.Id,
                            l.ISONumeric,
                            l.Name,
                            l.ISO2Code,
                            l.ISO3Code
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

    public async Task<RequestResponse> Update(LanguagePUT masterPUT)
    {
        try
        {
            //using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByIdName<Language>(masterPUT.Id, masterPUT.Name);
            var masterRecord = await repository.FindById<Language>(masterPUT.Id);

            ActionDTO actionDTO = new();
            actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.UtcNow : null;
            actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.UtcNow : null;

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                masterPUT.ISONumeric = (masterPUT.ISONumeric is not null) ? masterPUT.ISONumeric : masterRecord.ISONumeric;
                masterPUT.ISO2Code = (masterPUT.ISO2Code is not null) ? masterPUT.ISO2Code : masterRecord.ISO2Code;
                masterPUT.ISO3Code = (masterPUT.ISO3Code is not null) ? masterPUT.ISO3Code : masterRecord.ISO3Code;
                masterPUT.Name = (masterPUT.Name is not null) ? masterPUT.Name : masterRecord.Name;
                masterPUT.IconURL = (masterPUT.IconURL is not null) ? masterPUT.IconURL : masterRecord.IconURL;
                masterPUT.Code = (masterPUT.Code is not null) ? masterPUT.Code : masterRecord.Code;
                masterPUT.IsDefault = (masterPUT.IsDefault is not null) ? masterPUT.IsDefault : masterRecord.IsDefault;
                masterPUT.IsDraft = (masterPUT.IsDraft is not null) ? masterPUT.IsDraft : masterRecord.IsDraft;   
            }

            if (isExists == false)
            {
                masterRecord.ISONumeric = masterPUT.ISONumeric;
                masterRecord.Name = masterPUT.Name;
                masterRecord.ISO2Code = masterPUT.ISO2Code;
                masterRecord.ISO3Code = masterPUT.ISO3Code;
                masterRecord.IconURL = masterPUT.IconURL;
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
}
