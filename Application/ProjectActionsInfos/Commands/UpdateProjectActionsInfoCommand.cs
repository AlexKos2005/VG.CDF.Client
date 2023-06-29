using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.ProjectActionsInfos.Commands;

public class UpdateProjectActionsInfoCommand : EntityBaseDto
{
    public DateTime LastDateTimeConnection { get; set; }

    public DateTime LastDateTimeReportSending { get; set; }

    public DateTimeOffset LastDateTimeConnectionOffset { get; set; }

    public DateTimeOffset LastDateTimeReportSendingOffset { get; set; }

    public int AlarmMessageCounter { get; set; }

    public Guid ProjectId { get; set; }
    
}