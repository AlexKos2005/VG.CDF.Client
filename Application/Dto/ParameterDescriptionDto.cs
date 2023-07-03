
using System;

namespace VG.CDF.Client.Application.Dto
{
    public class ParameterDescriptionDto : EntityBaseDto
    {
        public string RusDescription { get; set; } = String.Empty;
        
        public string EngDescription { get; set; }= String.Empty;
        
        public string UkrDescription { get; set; }= String.Empty;
        public Guid ParameterId { get; set; }

    }
}
