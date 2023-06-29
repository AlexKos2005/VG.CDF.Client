using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VG.CDF.Client.Application.Wrappers;

namespace VG.CDF.Client.Infrastructure.Extentions;

public static class ResultExtentions
{
    public static async Task<Result<T>> GetFromHttpRespone<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            return new Result<T>(await response.Content.ReadFromJsonAsync<T>(),response.StatusCode.ToString()){IsError = false};
        }
        
        return new Result<T>(response.StatusCode.ToString()){IsError = true};
    }
    
    public static Result GetFromHttpRespone(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            return new Result(){IsError = false};
        }
        
        return new Result(){IsError = true};
    }
}