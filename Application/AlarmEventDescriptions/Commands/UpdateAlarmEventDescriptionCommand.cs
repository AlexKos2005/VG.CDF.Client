using System;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.AlarmEventDescriptions.Commands;

public class UpdateAlarmEventDescriptionCommand : EntityBaseDto
{
    public string RusDescription { get; set; } = String.Empty;
        
    public string EngDescription { get; set; }= String.Empty;
        
    public string UkrDescription { get; set; }= String.Empty;

    public Guid AlarmEventId { get; set; }
    
    
}