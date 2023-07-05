using System;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.Processes.Commands;

public class DeleteParameterFromProcessCommand : EntityBaseDto
{
    public Guid ParameterId { get; set; }
}