using System;
using VG.CDF.Client.Application.Enums;


namespace VG.CDF.Client.Application.Roles.Queries;

public class GetRolesListQuery
{
    public Guid? Id { get; set; } = null;
    public string? RoleName { get; set; } = null;
    public RoleCode? RoleCode { get; set; } = null;
    
}