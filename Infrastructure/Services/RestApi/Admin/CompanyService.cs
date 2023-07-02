using System.Net.Http;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi.Base;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;

public class CompanyService : WebApiServiceBase<CompanyDto>,ICompanyService
{
    protected const string _urn = "api/admin/Company/";

    public CompanyService(ICrudService<CompanyDto> crudService) : base(crudService)
    {
        base.Urn = _urn;
    }
}