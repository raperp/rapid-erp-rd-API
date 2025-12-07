using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.LoginModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class AuthenticationService(RapidERPDbContext context, ICommunicationService communication) : IAuthenticationService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> Login(Login login)
    {
        try
        {
            //await using var transaction = await context.Database.BeginTransactionAsync();
            
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);
            //var userId = await context.Users.Where(u => u.Email == login.Email).Select(u => u.Id).FirstOrDefaultAsync();
            var userIPWhitelist = await context.UserIPWhitelists.Where(x => x.UserId == user.Id).Select(x => x.IPAddress).FirstOrDefaultAsync();
            
            if (userIPWhitelist is not null)
            {
                if (user is not null)
                {
                    string generatedOTP = Guid.NewGuid().ToString().Substring(0, 6);
                    communication.SendEmail(user.Email, "Your OTP Code", $"Your OTP code is: {generatedOTP}", "");
                    await context.Users.Where(u => u.Email == login.Email).ExecuteUpdateAsync(u => u.SetProperty(user => user.OTP, generatedOTP));
                    var otp = await context.Users.Where(u => u.Email == login.Email).Select(u => u.OTP).FirstOrDefaultAsync();

                    if (generatedOTP == otp)
                    {
                        requestResponse = new()
                        {
                            StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                            IsSuccess = true,
                            Message = "Login Successful",
                            Data = new
                            {
                                user.Name,
                                user.Email,
                                user.Mobile,
                                IsLoginSuccessful = true
                            }
                        };
                    }

                    else
                    {
                        requestResponse = new()
                        {
                            StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                            IsSuccess = false,
                            Message = "OTP Verification Failed",
                            Data = new
                            {
                                IsLoginSuccessful = false
                            }
                        };
                    }
                }

                else
                {
                    // Failed login, return to the login page with an error message
                    requestResponse = new()
                    {
                        StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                        IsSuccess = false,
                        Message = "Invalid email or password",
                        Data = new
                        {
                            IsLoginSuccessful = false
                        }
                    };
                }
            }

            else 
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Unauthorized} {HTTPStatusCode.StatusCode401}",
                    IsSuccess = false,
                    Message = "Your IP Address not whitelisted",
                    Data = new
                    {
                        IsLoginSuccessful = false
                    }
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
                Message = ResponseMessage.WrongDataInput,
                Data = new
                {
                    IsLoginSuccessful = false
                }
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> ResetPassowrd(string email)
    {
        try
        {
            //await using var transaction = await context.Database.BeginTransactionAsync();

            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == email);
            
            if (user is not null)
            {
                string generatedOTP = Guid.NewGuid().ToString().Substring(0, 6);
                communication.SendEmail(user.Email, "Your OTP Code", $"Your OTP code is: {generatedOTP}", "");
                await context.Users.Where(u => u.Email == email).ExecuteUpdateAsync(u => u.SetProperty(user => user.OTP, generatedOTP));
                var otp = await context.Users.Where(u => u.Email == email).Select(u => u.OTP).FirstOrDefaultAsync();

                if (generatedOTP == otp)
                {
                    string generatedPassword = Guid.NewGuid().ToString().Substring(0, 9);
                    communication.SendEmail(user.Email, "Password Reset", $"Your New Password is: {generatedPassword}", "");
                    await context.Users.Where(u => u.Email == email).ExecuteUpdateAsync(u => u.SetProperty(user => user.Password, generatedPassword));
                    
                    requestResponse = new()
                    {
                        StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                        IsSuccess = true,
                        Message = "Password Reset Successful"
                    };
                }

                else
                {
                    requestResponse = new()
                    {
                        StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                        IsSuccess = false,
                        Message = "OTP Verification Failed"
                    };
                }
            }

            else
            {
                // Failed login, return to the login page with an error message
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                    IsSuccess = false,
                    Message = "Invalid email address"
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
