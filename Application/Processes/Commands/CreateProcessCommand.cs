using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace VG.CDF.Client.Application.Processes.Commands;

public class CreateProcessCommand
{
    public int ExternalId { get; set; }
    public int DeviceCode { get; set; }
    public string DeviceIp { get; set; } = string.Empty;
    public Guid ProjectId { get; set; }
}