using System;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.AlarmEventDescriptions.Commands;

public class UpdateAlarmEventDescriptionCommand : EntityBaseDto
{
    public string Description { get; set; } = string.Empty;

    public Guid AlarmEventId { get; set; }
    
    public Guid LanguageId { get; set; }
    
}