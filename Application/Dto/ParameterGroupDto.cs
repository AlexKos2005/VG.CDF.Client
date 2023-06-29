using System;

namespace VG.CDF.Client.Application.Dto;

public class ParameterGroupDto : EntityBaseDto
{
    public int ExternalId { get; set; }

    public string Name { get; set; } = string.Empty;
}