using AutoMapper;
using FluentValidation;
using MediatR;

namespace VG.CDF.Client.Application.ParameterGroups.Commands;

public class CreateParameterGroupCommand
{
    public int ExternalId { get; set; }

    public string Name { get; set; } = string.Empty;
    
}