using System;


namespace VG.CDF.Client.Application.Languages.Queries;

public class GetLanguagesListQuery
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;
    public string? Acronym { get; set; } = null;
    
}