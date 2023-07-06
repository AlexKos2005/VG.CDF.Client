using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VG.CDF.Client.Application.Dto.Reports;
using VG.CDF.Client.Application.Interfaces.Services;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Admin;

public class AlarmEventReportService : IAlarmEventReportService
{
    const string Urn = "api/admin/AlarmEventReport/GetAlarmEventsLiveReport";
    private readonly HttpClient _httpClient;

    public AlarmEventReportService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]> GetReport(AlarmEventsReportDataInfo reportData)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, Urn);
        request.Content = new StringContent(JsonConvert.SerializeObject(reportData), Encoding.UTF8, "application/json");
        
        var response = await _httpClient.SendAsync(request);

        return await response.Content.ReadAsByteArrayAsync();
    }
}