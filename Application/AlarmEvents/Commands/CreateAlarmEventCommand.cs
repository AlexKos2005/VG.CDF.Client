using System;

namespace VG.CDF.Client.Application.AlarmEvents.Commands;

public class CreateAlarmEventCommand
{
    public int ExternalId { get; set; }

    public Guid CompanyId { get; set; }
    
}