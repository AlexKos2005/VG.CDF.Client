using System;

namespace VG.CDF.Client.Application.ProcessDescriptions.Queries;

public class GetProcessDescriptionsListQuery
{
    public Guid? Id { get; set; } = null;
    public string? Description { get; set; } = null;

    public Guid? LanguageId { get; set; } = null;
        
    public Guid? ProcessId { get; set; } = null;
    
}