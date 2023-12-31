﻿using System;

namespace VG.CDF.Client.Application.ParameterDescriptions.Queries;

public class GetParameterDescriptionsListQuery
{
    public Guid? Id { get; set; } = null;
    public Guid? CompanyId { get; set; } = null;
    public string? RusDescription { get; set; } = null;
        
    public string? EngDescription { get; set; } = null;
        
    public string? UkrDescription { get; set; } = null;
    public Guid? ParameterId { get; set; }= null;
}