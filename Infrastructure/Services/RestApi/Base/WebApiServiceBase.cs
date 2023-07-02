using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Application.Wrappers;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Base;

public abstract class WebApiServiceBase<T> : IWebApiService<T> where T: EntityBaseDto
{
    protected string Urn { get; set; }
    private readonly ICrudService<T> _crudService;
    public WebApiServiceBase(ICrudService<T> crudService)
    {
        _crudService = crudService;
    }
    
    public async Task<IEnumerable<T>> GetList<Tg>(Tg entity)
    {
        var result = await _crudService.Get<IEnumerable<T>>(Urn,entity);

        if (result.IsError)
        {
            return Enumerable.Empty<T>();
        }

        return result.ResultContent;
    }

    public async Task<T?> Create<Tc>(Tc entity)
    {
        var result = await _crudService.Post<T>(Urn,entity);

        if (result.IsError)
        {
            return default(T);
        }

        return result.ResultContent;
    }

    public async Task<T?> Update<Tu>(Tu entity)
    {
        var result = await _crudService.Update<T>(Urn,entity);

        if (result.IsError)
        {
            return default(T);
        }

        return result.ResultContent;
    }

    public async Task<bool> Delete<Td>(Td entity)
    {
        var result = await _crudService.Delete(Urn,entity);

        if (result.IsError)
        {
            return false;
        }

        return true;
    }
}