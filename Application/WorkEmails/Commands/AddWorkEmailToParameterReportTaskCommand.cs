using System;
using VG.CDF.Client.Application.Dto;


namespace VG.CDF.Client.Application.WorkEmails.Commands;

public class AddWorkEmailToParameterReportTaskCommand : EntityBaseDto
{
    public Guid Id { get; set; }
    public Guid ParameterReportTaskId { get; set; }
    
}
