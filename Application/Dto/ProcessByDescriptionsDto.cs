using System;

namespace VG.CDF.Client.Application.Dto;

public class ProcessByDescriptionsDto : EntityBaseDto
{
    public string RusDescription { get; set; }
        
    public string EngDescription { get; set; }
        
    public string UkrDescription { get; set; }
    
    public int DeviceCode { get; set; }
    public string DeviceIp { get; set; } = String.Empty;
        
    public Guid ProcessId { get; set; }
    
    public int ExternalId { get; set; }
    
    public Guid ProjectId { get; set; }
    
    
}