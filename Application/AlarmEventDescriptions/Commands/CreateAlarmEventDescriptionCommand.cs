using System;

namespace VG.CDF.Client.Application.AlarmEventDescriptions.Commands;

public class CreateAlarmEventDescriptionCommand
{
    public string RusDescription { get; set; } = String.Empty;
        
    public string EngDescription { get; set; }= String.Empty;
        
    public string UkrDescription { get; set; }= String.Empty;

    public Guid AlarmEventId { get; set; }
    
    public Guid DescriptionsLanguageId { get; set; }
    
}