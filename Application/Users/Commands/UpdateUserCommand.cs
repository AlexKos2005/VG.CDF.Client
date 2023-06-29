using System;
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.Users.Commands;

public class UpdateUserCommand : EntityBaseDto
{
    public string Email { get; set; } = string.Empty;
    
    public Guid RoleId { get; set; }
    
}