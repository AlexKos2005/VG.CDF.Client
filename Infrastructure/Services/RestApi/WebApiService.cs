using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi.Base;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;

public class WebApiService<T>: WebApiServiceBase<T>, IWebApiService<T> where T:EntityBaseDto
{
    public WebApiService(ICrudService<T> crudService, string urn) : base(crudService, urn)
    {
    }
}