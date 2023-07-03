using System;
using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.Dto;

public class ParameterByDescriptionsDto
{
    public int ExternalId { get; set; }

    public ParameterValueType ValueType { get; set; }
        
    public Guid CompanyId { get; set; }

    public Guid ParameterGroupId { get; set; }
    public string RusDescription { get; set; } = String.Empty;
        
    public string EngDescription { get; set; }= String.Empty;
        
    public string UkrDescription { get; set; }= String.Empty;
    public Guid ParameterId { get; set; }
}