using System;

namespace VG.CDF.Client.Application.ProjectActionsInfos.Queries;

public class GetProjectActionsInfoListQuery
{
    public Guid? Id { get; set; } = null;
    
    public DateTime? LastDateTimeConnection { get; set; } = null;

    public DateTime? LastDateTimeReportSending { get; set; } = null;

    public DateTimeOffset? LastDateTimeConnectionOffset { get; set; } = null;

    public DateTimeOffset? LastDateTimeReportSendingOffset { get; set; } = null;

    public int? AlarmMessageCounter { get; set; } = null;

    public Guid? ProjectId { get; set; } = null;
    
}