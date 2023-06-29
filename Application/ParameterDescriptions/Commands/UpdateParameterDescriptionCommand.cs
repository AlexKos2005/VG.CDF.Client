using System;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.ParameterDescriptions.Commands;

public class UpdateParameterDescriptionCommand : EntityBaseDto
{
    public string Description { get; set; } = string.Empty;

    public Guid LanguageId { get; set; }

    public Guid ParameterId { get; set; }
    
}