using System;

namespace VG.CDF.Client.Application.ParameterDescriptions.Commands;

public class CreateParameterDescriptionCommand 
{
    public string Description { get; set; } = string.Empty;

    public Guid LanguageId { get; set; }

    public Guid ParameterId { get; set; }
    
}