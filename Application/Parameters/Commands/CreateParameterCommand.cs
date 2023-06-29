using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.Parameters.Commands;

public class CreateParameterCommand 
{
    public int ExternalId { get; set; }

    public ParameterValueType ValueType { get; set; }
        
    public Guid CompanyId { get; set; }

    public Guid ParameterGroupId { get; set; }
    
}