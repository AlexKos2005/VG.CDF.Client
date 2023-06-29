using System;
using System.Reflection.Metadata;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Enums;
using VG.CDF.Client.Dto;

namespace VG.CDF.Client.Application.Parameters.Commands;

public class UpdateParameterCommand : EntityBaseDto
{
    public int ExternalId { get; set; }

    public ParameterValueType ValueType { get; set; }
        
    public Guid CompanyId { get; set; }

    public Guid ParameterGroupId { get; set; }
    
}