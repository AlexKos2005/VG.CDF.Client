using System;

namespace VG.CDF.Client.Application.Dto;

public class AlarmEventDto : EntityBaseDto
{
    public Guid Id { get; set; }

    public int ExternalId { get; set; }

    public int CompanyId { get; set; }

}