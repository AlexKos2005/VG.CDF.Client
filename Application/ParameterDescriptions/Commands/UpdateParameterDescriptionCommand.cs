using System;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.ParameterDescriptions.Commands;

public class UpdateParameterDescriptionCommand : EntityBaseDto
{
    public string RusDescription { get; set; } = String.Empty;
        
    public string EngDescription { get; set; }= String.Empty;
        
    public string UkrDescription { get; set; }= String.Empty;

    public Guid ParameterId { get; set; }
    
}