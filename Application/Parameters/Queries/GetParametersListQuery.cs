using System;
using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.Parameters.Queries;

public class GetParametersListQuery
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;

    public ParameterValueType? ValueType { get; set; } = null;

    public Guid? CompanyId { get; set; } = null;

    public Guid? ParameterGroupId { get; set; } = null;
    
}