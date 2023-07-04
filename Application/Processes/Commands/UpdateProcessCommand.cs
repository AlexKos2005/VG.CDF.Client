using System;
using System.Diagnostics;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.Processes.Commands;

public class UpdateProcessCommand : EntityBaseDto
{
    public int ExternalId { get; set; }
    public int DeviceCode { get; set; }
    public string DeviceIp { get; set; } = string.Empty;
    public Guid ProjectId { get; set; }
    
}