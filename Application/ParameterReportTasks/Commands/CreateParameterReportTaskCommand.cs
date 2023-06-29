using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Dto;

namespace VG.CDF.Client.Application.ParameterReportTasks.Commands;

public class CreateParameterReportTaskCommand : EntityBaseDto
{
    public Guid ProjectId { get; set; }
    public bool IsActive { get; set; }
}
