using System;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace VG.CDF.Client.Application.Projects.Commands;

public class CreateProjectCommand
{
    public int ExternalId { get; set; }

    public int UtcOffset { get; set; }

    public string Description { get; set; } = string.Empty;
        
    public Guid CompanyId { get; set; }
    
}