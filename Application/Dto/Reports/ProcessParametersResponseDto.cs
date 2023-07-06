using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Client.Application.Dto.Reports
{
    public class ProcessParametersResponseDto
    {
        public ProcessWithDescriptionsDto Process { get; set; } = new ProcessWithDescriptionsDto();
        public List<ParametersWithDescriptions> Parameters { get; set; } = new List<ParametersWithDescriptions>();
    }
}
