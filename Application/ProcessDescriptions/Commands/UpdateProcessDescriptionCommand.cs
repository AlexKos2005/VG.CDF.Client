using System;
using System.Diagnostics;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Dto;


namespace VG.CDF.Client.Application.ProcessDescriptions.Commands;

public class UpdateProcessDescriptionCommand : EntityBaseDto
{
    public string Description { get; set; } = string.Empty;

    public Guid LanguageId { get; set; }
        
    public Guid ProcessId { get; set; }
    
}