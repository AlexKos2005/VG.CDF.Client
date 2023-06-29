using System;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.AlarmEvents.Commands;

public class UpdateAlarmEventCommand : EntityBaseDto
{
    public int ExternalId { get; set; }

    public Guid CompanyId { get; set; }
}