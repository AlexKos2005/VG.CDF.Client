using System;

namespace VG.CDF.Client.Application.Dto;

public class UserDto : EntityBaseDto
{

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; }= string.Empty;

    public int RoleId { get; set; }
    
}