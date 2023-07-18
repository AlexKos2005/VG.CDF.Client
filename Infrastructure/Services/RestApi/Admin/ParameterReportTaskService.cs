using System.Net.Http;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi.Base;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Admin;

public class ParameterReportTaskService : WebApiServiceBase<ParameterReportTaskDto>,IParameterReportTaskService
{
    protected const string _urn = "api/admin/ParameterReportTask/";

    public ParameterReportTaskService(ICrudService<ParameterReportTaskDto> crudService, IMessagePresentService messagePresentService) 
        : base(crudService,messagePresentService)
    {
        base.Urn = _urn;
    }
}