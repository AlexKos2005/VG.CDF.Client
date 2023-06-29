using System;

namespace VG.CDF.Client.Application.AlarmEventDescriptions.Commands;

public class CreateAlarmEventDescriptionCommand
{
    public string Description { get; set; } = string.Empty;

    public Guid AlarmEventId { get; set; }
    
    public Guid DescriptionsLanguageId { get; set; }
    
}