using System;

using AutoMapper;
using FluentValidation;


namespace VG.CDF.Client.Application.ProcessDescriptions.Commands;

public class CreateProcessDescriptionCommand
{
    public string Description { get; set; } = string.Empty;

    public Guid LanguageId { get; set; }
        
    public Guid ProcessId { get; set; }
    
}