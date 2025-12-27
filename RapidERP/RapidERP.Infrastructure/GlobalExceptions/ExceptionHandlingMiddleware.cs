using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using RapidERP.Application.DTOs.Shared;
using System.Net;

namespace RapidERP.Infrastructure.GlobalExceptions;

public class ExceptionHandlingMiddleware 
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";
            HttpResponseDTO httpResponseDTO = new();

            switch (ex)
            {
                case KeyNotFoundException keyNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    httpResponseDTO.StatusCode = (int)HttpStatusCode.NotFound;
                    httpResponseDTO.Message = keyNotFoundException.Message;
                    break;
                case UnauthorizedAccessException unauthorizedAccessException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpResponseDTO.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpResponseDTO.Message = unauthorizedAccessException.Message;
                    break;
                case DataNotFoundException dataNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    httpResponseDTO.StatusCode = (int)HttpStatusCode.NotFound;
                    httpResponseDTO.Message = dataNotFoundException.Message;
                    break;
                case ApplicationException applicationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpResponseDTO.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpResponseDTO.Message = applicationException.Message;
                    break;
                case JsonReaderException jsonReaderException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpResponseDTO.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpResponseDTO.Message = jsonReaderException.Message;
                    break;
                case JsonSerializationException jsonSerializationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpResponseDTO.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpResponseDTO.Message = jsonSerializationException.Message;
                    break;
                case InvalidOperationException invalidOperationException:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpResponseDTO.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpResponseDTO.Message = invalidOperationException.Message;
                    break;
                case SqlException sqlException:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpResponseDTO.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpResponseDTO.Message = sqlException.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpResponseDTO.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpResponseDTO.Message = "Internal Server Error";
                    break;
            }
            var result = JsonConvert.SerializeObject(httpResponseDTO);
            await response.WriteAsync(result);
            //await HandleExceptionAsync(httpContext, ex);
        }
    }

    //private Task HandleExceptionAsync(HttpContext context, Exception exception)
    //{
    //    // Log the exception and return a proper response
    //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    //    return context.Response.WriteAsync("An unexpected error occurred.");
    //}
}
