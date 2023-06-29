

using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.Roles.Commands;

public class CreateRoleCommand
{
    public string RoleName { get; set; } = string.Empty;

    public RoleCode RoleCode { get; set; }
}