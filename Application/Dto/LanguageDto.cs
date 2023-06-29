using System;

namespace VG.CDF.Client.Application.Dto;

public class LanguageDto : EntityBaseDto
{
    public int ExternalId { get; set; }
    public string Acronym { get; set; } = string.Empty;
}