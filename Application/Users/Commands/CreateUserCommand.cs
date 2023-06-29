using System;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace VG.CDF.Client.Application.Users.Commands;

public class CreateUserCommand
{
    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; }= string.Empty;

    public Guid RoleId { get; set; }
    
}