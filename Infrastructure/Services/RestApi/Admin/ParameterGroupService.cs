using System.Net.Http;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi.Base;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Admin;

public class ParameterGroupService : WebApiServiceBase<ParameterGroupDto>,IParameterGroupService
{
    private const string _uri = "api/admin/ParameterGroup/";

    public ParameterGroupService(ICrudService<ParameterGroupDto> crudService) : base(crudService, _uri)
    {
    }
}