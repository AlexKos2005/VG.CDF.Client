using System;

namespace VG.CDF.Client.Application.AlarmEventDescriptions.Queries;

public class GetAlarmEventDescriptionsListQuery
{
    public Guid? Id { get; set; } = null;
    public string? RusDescription { get; set; } = null;
        
    public string? EngDescription { get; set; } = null;
        
    public string? UkrDescription { get; set; } = null;
    public Guid? AlarmEventId { get; set; }= null;
    
}