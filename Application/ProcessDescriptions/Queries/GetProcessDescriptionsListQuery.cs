using System;

namespace VG.CDF.Client.Application.ProcessDescriptions.Queries;

public class GetProcessDescriptionsListQuery
{
    public Guid? Id { get; set; } = null;
    public string? RusDescription { get; set; } = null;
        
    public string? EngDescription { get; set; } = null;
        
    public string? UkrDescription { get; set; } = null;
    
    public Guid? ProjectId { get; set; } = null;
    public Guid? ProcessId { get; set; } = null;
    
}