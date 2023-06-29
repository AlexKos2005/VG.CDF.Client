using System;

namespace VG.CDF.Client.Application.ParameterGroups.Queries;

public class GetParameterGroupsListQuery
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;
    public string? Name { get; set; } = null;
    
}