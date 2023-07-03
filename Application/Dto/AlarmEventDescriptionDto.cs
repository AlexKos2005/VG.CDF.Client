
using System;

namespace VG.CDF.Client.Application.Dto
{
    public class AlarmEventDescriptionDto : EntityBaseDto
    {
        public string RusDescription { get; set; }
        
        public string EngDescription { get; set; }
        
        public string UkrDescription { get; set; }
        
        public Guid AlarmEventId { get; set; }

    }
}
