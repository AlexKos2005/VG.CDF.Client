

using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.Dto;

public class RoleDto : EntityBaseDto
{
    public string RoleName { get; set; } = string.Empty;

    public RoleCode RoleCode { get; set; }
}