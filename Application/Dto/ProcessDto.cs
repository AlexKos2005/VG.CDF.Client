using System;

namespace VG.CDF.Client.Application.Dto;

public class ProcessDto : EntityBaseDto
{
    public int ExternalId { get; set; }
    public Guid ProjectId { get; set; }
    public int DeviceCode { get; set; }
    public string DeviceIp { get; set; } = String.Empty;

}