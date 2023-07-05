using System;

namespace VG.CDF.Client.Application.Dto;

public class CheckedElementDto
{
    public Guid ElementId { get; set; }
    
    public int ElementExternalId { get; set; }
    
    public bool IsChecked { get; set; }
}