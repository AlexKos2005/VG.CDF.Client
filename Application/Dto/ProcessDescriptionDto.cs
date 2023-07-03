using System;

namespace VG.CDF.Client.Application.Dto;

public class ProcessDescriptionDto : EntityBaseDto
{
    public string RusDescription { get; set; }
        
    public string EngDescription { get; set; }
        
    public string UkrDescription { get; set; }
        
    public Guid ProcessId { get; set; }
}