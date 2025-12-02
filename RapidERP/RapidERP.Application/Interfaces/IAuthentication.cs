using RapidERP.Domain.Entities.LoginModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface IAuthentication
{
    Task<RequestResponse> Login(Login login);
    //Task<RequestResponse> VerifyOTP(string otp);
}
