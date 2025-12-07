namespace RapidERP.Application.Interfaces;

public interface ICommunicationService
{
    string SendEmail(string to, string subject, string body, string parameter);
}
