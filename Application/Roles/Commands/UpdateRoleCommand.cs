using VG.CDF.Client.Application.Dto;


namespace VG.CDF.Client.Application.Roles.Commands;

public class UpdateRoleCommand : EntityBaseDto
{
    public string Name { get; set; } = string.Empty;
}