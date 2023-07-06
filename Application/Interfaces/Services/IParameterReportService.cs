using System.Threading.Tasks;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Dto.Reports;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Application.Processes.Commands;

namespace VG.CDF.Client.Application.Interfaces.Services;

public interface IParameterReportService
{
    Task<byte[]> GetReport(ProcessParametersReportDataInfo reportData);
    
}