using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Application.Processes.Commands;
using VG.CDF.Client.Infrastructure.Services.RestApi.Base;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Admin;

public class ProcessService : WebApiServiceBase<ProcessDto>,IProcessService
{
    protected const string _urn = "api/admin/Process/";

    public ProcessService(ICrudService<ProcessDto> crudService) : base(crudService)
    {
        base.Urn = _urn;
    }

    public async Task<bool> AddParametersToProcess(AddParametersToProcessCommand command)
    {
        var result = await _crudService.Post<bool>(_urn+"AddParametersToProcess",command);

        if (result.IsError)
        {
            return default(bool);
        }

        return result.ResultContent;
    }
    
    public async Task<bool> DeleteParametersFromProcess(DeleteParameterFromProcessCommand command)
    {
        var result = await _crudService.DeleteByBody(Urn+"DeleteParameterFromProcess",command);

        if (result.IsError)
        {
            return false;
        }

        return true;
    }
}