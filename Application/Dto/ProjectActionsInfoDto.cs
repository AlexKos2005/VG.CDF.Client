using System;

namespace VG.CDF.Client.Application.Dto;

public class ProjectActionsInfoDto : EntityBaseDto
{
    public DateTime LastDateTimeConnection { get; set; }

    public DateTime LastDateTimeReportSending { get; set; }

    public DateTimeOffset LastDateTimeConnectionOffset { get; set; }

    public DateTimeOffset LastDateTimeReportSendingOffset { get; set; }

    public int AlarmMessageCounter { get; set; }

    public int ProjectId { get; set; }
    
}