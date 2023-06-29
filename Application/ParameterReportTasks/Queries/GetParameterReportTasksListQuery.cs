using System;
using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.ParameterReportTasks.Queries;

public class GetParameterReportTasksListQuery
{
    public Guid? Id { get; set; } = null;
    public Guid? ProjectId { get; set; } = null;
    public bool? IsActive { get; set; } = null;
    public DateTimeOffset? LastSendDt { get; set; } = null;

    public ReportTaskStatus? Status { get; set; } = null;

}
