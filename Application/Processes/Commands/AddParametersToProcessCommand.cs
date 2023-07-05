using System;
using VG.CDF.Client.Application.Dto;


namespace VG.CDF.Client.Application.Processes.Commands;

public class AddParametersToProcessCommand : EntityBaseDto
{
    public Guid[] ParametersId { get; set; } = Array.Empty<Guid>();
    
}