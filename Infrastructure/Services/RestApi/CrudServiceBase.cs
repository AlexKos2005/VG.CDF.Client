using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Application.Wrappers;
using VG.CDF.Client.Infrastructure.Extentions;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;

public abstract class CrudServiceBase<T>: ICrudService<T>
{
    private readonly HttpClient _httpClient;
    private readonly string _url;
    private readonly ILocalStorageService _localStorage;
    public CrudServiceBase(HttpClient httpClient, ILocalStorageService localStorage,string url)
    {
        _httpClient = httpClient;
        _url = url;
        _localStorage = localStorage;
    }
    
    
    public virtual async Task<Result<T>> Get<T>(string urn,object content)
    {
        // create request object
        var request = new HttpRequestMessage(HttpMethod.Get, urn);

        // set request body
        request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

        var jwt = await _localStorage.GetItemAsStringAsync("authToken");
        // add authorization header
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        // send request
        var response = await _httpClient.SendAsync(request);

        return await response.GetFromHttpRespone<T>();
    }

    public virtual async Task<Result<T>> Post<T>(string urn,object content)
    {
        // create request object
        var request = new HttpRequestMessage(HttpMethod.Post, urn);

        // set request body
        request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

        var jwt = await _localStorage.GetItemAsStringAsync("authToken");
        // add authorization header
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        // send request
        var response = await _httpClient.SendAsync(request);

        return await response.GetFromHttpRespone<T>();
    }

    public virtual async Task<Result<T>> Update<T>(string urn,object content)
    {
        // create request object
        var request = new HttpRequestMessage(HttpMethod.Put, urn);

        // set request body
        request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

        var jwt = await _localStorage.GetItemAsStringAsync("authToken");
        // add authorization header
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        // send request
        var response = await _httpClient.SendAsync(request);

        return await response.GetFromHttpRespone<T>();
    }

    public virtual async Task<Result> Delete(string urn,object content)
    {
        // create request object
        var request = new HttpRequestMessage(HttpMethod.Delete, urn);

        // set request body
        request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

        var jwt = await _localStorage.GetItemAsStringAsync("authToken");
        // add authorization header
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        // send request
        var response = await _httpClient.SendAsync(request);

        return response.GetFromHttpRespone();
    }
}