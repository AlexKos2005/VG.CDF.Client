using System;

namespace VG.CDF.Client.Application.Projects.Queries;

public class GetProjectsListQuery
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;

    public int? UtcOffset { get; set; }= null;

    public string? Description { get; set; } = null;
        
    public Guid? CompanyId { get; set; } = null;
    
}