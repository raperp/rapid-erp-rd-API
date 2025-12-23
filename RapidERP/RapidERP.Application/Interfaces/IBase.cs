using RapidERP.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapidERP.Application.Interfaces;

public interface IBase<T> where T : class
{
    Task<RequestResponse> GetAll(int skip, int take, int pageSize);
    Task<dynamic> GetSingle(int id);
    Task<RequestResponse> GetHistory(int skip, int take, int pageSize);
    Task<RequestResponse> GetTemplate();
    Task<RequestResponse> CreateSingle(T masterPOST);
    Task<RequestResponse> CreateBulk(List<T> masterPOSTs);
    Task<RequestResponse> Update(T masterPUT);
    Task<RequestResponse> Delete(int id);
    Task<dynamic> SoftDelete(int id);
}
