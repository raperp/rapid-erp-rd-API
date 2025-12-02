namespace RapidERP.Application.Interfaces;

public interface ICommunication
{
    string SendEmail(string to, string subject, string body, string parameter);
}
