using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Dto.Reports;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.EndPoints;
using VG.CDF.Client.Infrastructure.Extentions;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Admin;

public class ParameterReportService : IParameterReportService
{
    const string Urn = "api/admin/ParameterReport/GetTagsLiveReport";
    private readonly HttpClient _httpClient;
    public ParameterReportService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<byte[]> GetReport(ProcessParametersReportDataInfo reportData)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, Urn);
        request.Content = new StringContent(JsonConvert.SerializeObject(reportData), Encoding.UTF8, "application/json");
        
        var response = await _httpClient.SendAsync(request);

        return await response.Content.ReadAsByteArrayAsync();
        
    }
}