using System;
namespace VG.CDF.Client.Application.AlarmEvents.Queries;

public class GetAlarmEventsListQuery
{
    public Guid? Id { get; set; } = null;

    public int? ExternalId { get; set; } = null;

    public Guid? CompanyId { get; set; } = null;
    
}