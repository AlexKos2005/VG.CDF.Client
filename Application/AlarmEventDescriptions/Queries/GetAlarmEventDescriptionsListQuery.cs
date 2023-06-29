using System;

namespace VG.CDF.Client.Application.AlarmEventDescriptions.Queries;

public class GetAlarmEventDescriptionsListQuery
{
    public Guid? Id { get; set; } = null;
    public string? Description { get; set; } = null;
    public Guid? AlarmEventId { get; set; }= null;
    
    public Guid? DescriptionsLanguageId { get; set; }= null;
}