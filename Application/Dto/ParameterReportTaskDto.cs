using System;
using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.Dto
{
    public class ParameterReportTaskDto : EntityBaseDto
    {
        public Guid ProjectId { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastSendDt { get; set; }
        
        public  ReportTaskStatus Status { get; set; }
        
    }
}
