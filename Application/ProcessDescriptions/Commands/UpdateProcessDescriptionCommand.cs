using System;
using System.Diagnostics;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Dto;


namespace VG.CDF.Client.Application.ProcessDescriptions.Commands;

public class UpdateProcessDescriptionCommand : EntityBaseDto
{
    public string RusDescription { get; set; } = String.Empty;
        
    public string EngDescription { get; set; }= String.Empty;
        
    public string UkrDescription { get; set; }= String.Empty;
        
    public Guid ProcessId { get; set; }
    
}