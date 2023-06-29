using VG.CDF.Client.Application.Dto;


namespace VG.CDF.Client.Application.Companies.Commands;

public class UpdateCompanyCommand : EntityBaseDto
{
    public string Name { get; set; } = string.Empty;
    
}