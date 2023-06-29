using System.Diagnostics;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.Projects.Commands;

public class UpdateProjectCommand : EntityBaseDto
{
    public string Name { get; set; } = string.Empty;
    
}