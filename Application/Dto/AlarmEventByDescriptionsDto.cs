using System;
using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.Dto;

public class AlarmEventByDescriptionsDto
{
    public string RusDescription { get; set; }
        
    public string EngDescription { get; set; }
        
    public string UkrDescription { get; set; }
        
    public Guid AlarmEventId { get; set; }
    
    public int ExternalId { get; set; }

    public Guid CompanyId { get; set; }
    
}