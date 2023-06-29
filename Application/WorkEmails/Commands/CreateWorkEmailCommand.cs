using AutoMapper;
using FluentValidation;
using MediatR;

namespace VG.CDF.Client.Application.WorkEmails.Commands;

public class CreateWorkEmailCommand
{
    public string Email { get; set; } = string.Empty;
    
}
