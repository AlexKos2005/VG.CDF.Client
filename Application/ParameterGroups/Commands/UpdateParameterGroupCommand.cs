
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.ParameterGroups.Commands;

public class UpdateParameterGroupCommand : EntityBaseDto
{
    public int ExternalId { get; set; }

    public string Name { get; set; } = string.Empty;
    
}