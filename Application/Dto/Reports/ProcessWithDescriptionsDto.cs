using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Client.Application.Dto.Reports
{
    public class ProcessWithDescriptionsDto
    {
        public Guid Id { get; set; }
        public int ExternalId { get; set; }
        public Guid ProjectId { get; set; }
        public bool IsEnabled { get; set; }

    }
}
