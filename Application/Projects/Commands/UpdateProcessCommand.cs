using System.Diagnostics;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.Projects.Commands;

public class UpdateProjectCommand : EntityBaseDto
{
    public int ExternalId { get; set; }
    public string Description { get; set; } = string.Empty;
    
}