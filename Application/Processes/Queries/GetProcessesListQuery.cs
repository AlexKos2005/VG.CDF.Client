using System;

namespace VG.CDF.Client.Application.Processes.Queries;

public class GetProcessesListQuery
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;
    public int? DeviceCode { get; set; } = null;
    public string? DeviceIp { get; set; } = null;
    public Guid? ProjectId { get; set; } = null;
    
}