using System.Net.Http;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi.Base;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;

public class CrudService<T>: CrudServiceBase<T>, ICrudService<T>
{
    public CrudService(
        HttpClient httpClient, 
        ILocalStorageService localStorage) 
        : base(httpClient, localStorage)
    {
    }
}