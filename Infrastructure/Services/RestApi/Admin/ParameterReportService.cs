using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Dto.Reports;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.EndPoints;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Admin;

public class ParameterReportService : IParameterReportService
{
    private const string _urn = "api/admin/ParameterReport";
    private readonly HttpClient _httpClient;
    public ParameterReportService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<byte[]> GetReport(ProcessParametersReportDataInfo reportData)
    {
        var response = await _httpClient.PostAsJsonAsync(_urn, reportData);

        response.EnsureSuccessStatusCode();
        
        var fileBytes = await response.Content.ReadAsByteArrayAsync();

        return fileBytes;
    }
}