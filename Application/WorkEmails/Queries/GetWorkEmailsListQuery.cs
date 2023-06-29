using System;

namespace VG.CDF.Client.Application.WorkEmails.Commands;

public class GetWorkEmailsListQuery
{
    //
    public Guid? Id { get; set; } = null;
    public Guid? ParameterReportTaskId { get; set; } = null;
    public string? Email { get; set; } = null;

}
