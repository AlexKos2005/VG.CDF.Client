using VG.CDF.Client.Application.Dto;

namespace VG.CDF.Client.Application.WorkEmails.Commands;

public class UpdateWorkEmailCommand : EntityBaseDto
{
    public string Email { get; set; } = string.Empty;
}
