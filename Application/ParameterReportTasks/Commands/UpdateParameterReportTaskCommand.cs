using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Enums;
using VG.CDF.Client.Dto;

namespace VG.CDF.Client.Application.ParameterReportTasks.Commands;

public class UpdateParameterReportTaskCommand : EntityBaseDto
{
    public bool IsActive { get; set; }
    public DateTime LastSendDt { get; set; }
    public ReportTaskStatus Status { get; set; }
}
