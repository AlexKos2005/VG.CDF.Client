using System.Net.Http;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi.Base;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Admin;

public class ProcessDescriptionService : WebApiServiceBase<ProcessDescriptionDto>,IProcessDescriptionService
{
    private const string _uri = "api/admin/ProcessDescription/";

    public ProcessDescriptionService(ICrudService<ProcessDescriptionDto> crudService) : base(crudService, _uri)
    {
    }
}