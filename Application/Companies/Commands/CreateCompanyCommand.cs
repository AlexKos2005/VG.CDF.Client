using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace VG.CDF.Client.Application.Companies.Commands;

public class CreateCompanyCommand
{
    public string Name { get; set; } = string.Empty;
}