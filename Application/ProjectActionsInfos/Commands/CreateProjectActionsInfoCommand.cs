using System;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace VG.CDF.Client.Application.ProjectActionsInfos.Commands;

public class CreateProjectActionsInfoCommand
{
    public DateTime LastDateTimeConnection { get; set; }

    public DateTime LastDateTimeReportSending { get; set; }

    public DateTimeOffset LastDateTimeConnectionOffset { get; set; }

    public DateTimeOffset LastDateTimeReportSendingOffset { get; set; }

    public int AlarmMessageCounter { get; set; }

    public int ProjectId { get; set; }

}