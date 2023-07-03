using System;

using AutoMapper;
using FluentValidation;


namespace VG.CDF.Client.Application.ProcessDescriptions.Commands;

public class CreateProcessDescriptionCommand
{
    public string RusDescription { get; set; } = String.Empty;
        
    public string EngDescription { get; set; }= String.Empty;
        
    public string UkrDescription { get; set; }= String.Empty;

    public Guid ProcessId { get; set; }
    
}