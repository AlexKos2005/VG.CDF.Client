using System.Net.Http;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;

public class CompanyService : CrudServiceBase<CompanyDto>,ICompanyService
{
    private const string _uri = "api/Company/";

    public CompanyService(HttpClient httpClient, ILocalStorageService localStorage) : base(httpClient, localStorage, _uri)
    {
    }
}