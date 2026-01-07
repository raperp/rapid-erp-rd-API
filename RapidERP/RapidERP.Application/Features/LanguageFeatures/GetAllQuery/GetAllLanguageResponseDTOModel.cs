namespace RapidERP.Application.Features.LanguageFeatures.GetAllQuery;

public record GetAllLanguageResponseDTOModel
{
    public int Id { get; set; }
    public string ISONumeric { get; set; }
    public string Name { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string IconURL { get; set; }
}
