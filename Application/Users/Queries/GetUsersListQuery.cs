using System;

namespace VG.CDF.Client.Application.Users.Queries;

public class GetUsersListQuery
{
    public Guid? Id { get; set; } = null;

    public string? Email { get; set; } = null;

    public Guid? RoleId { get; set; } = null;
    
}