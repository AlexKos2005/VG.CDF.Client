using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace VG.CDF.Client.Application.Languages.Commands;

public class CreateLanguageCommand
{
    public int ExternalId { get; set; }
    public string Acronym { get; set; } = string.Empty;
}