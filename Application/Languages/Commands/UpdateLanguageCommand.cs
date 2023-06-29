
using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.Languages.Commands;

public class UpdateLanguageCommand : EntityBaseDto
{
    public string Name { get; set; } = string.Empty;
    
}