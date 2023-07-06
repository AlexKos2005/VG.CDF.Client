using System;

namespace VG.CDF.Client.Application.Dto;

public class CheckedElementDto
{
    public Guid ElementId { get; set; }
    
    public int ElementExternalId { get; set; }

    public string RuDescr { get; set; } = String.Empty;
    
    public string UkrDescr { get; set; } = String.Empty;
    
    public string CurrentDescr { get; set; } = String.Empty;
    public bool IsChecked { get; set; }
}