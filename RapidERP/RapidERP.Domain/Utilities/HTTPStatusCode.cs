namespace RapidERP.Domain.Utilities;

public static class HTTPStatusCode
{
    public static int OK = 200;
    public static int Created = 201;
    public static int NoContent = 204;
    public static int MovedPermanently = 301;
    public static int Found_TemporaryRedirect = 302;
    public static int BadRequest = 400;
    public static int Unauthorized = 401;
    public static int Forbidden = 403;
    public static int NotFound = 404;
    public static int Conflict = 409;
    public static int InternalServerError = 500;
    public static int BadGateway = 502;
    public static int ServiceUnavailable = 503;

    public static string StatusCode200 = "OK";
    public static string StatusCode201 = "CREATED";
    public static string StatusCode204 = "NO CONTENT";
    public static string StatusCode301 = "MOVED PERMANENTLY";
    public static string StatusCode302 = "FOUND TEMPORARY REDIRECT";
    public static string StatusCode400 = "BAD REQUEST";
    public static string StatusCode401 = "UNAUTHORIZED";
    public static string StatusCode403 = "FORBIDDEN";
    public static string StatusCode404 = "NOT FOUND";
    public static string StatusCode409 = "CONFLICT";
    public static string StatusCode500 = "INTERNAL SERVER ERROR";
    public static string StatusCode502 = "BAD GATEWAY";
    public static string StatusCode503 = "SERVICE UNAVAILABLE";
}
