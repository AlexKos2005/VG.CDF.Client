using System;
using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.Dto;

public class ParameterDto : EntityBaseDto
{
    public int ExternalId { get; set; }

    public ParameterValueType ValueType { get; set; }
        
    public Guid CompanyId { get; set; }

    public Guid ParameterGroupId { get; set; }

}